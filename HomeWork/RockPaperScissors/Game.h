#pragma once
#define WIN32_LEAN_AND_MEAN
#include <winsock2.h>
#include <ws2tcpip.h>
#include <windows.h>
#include <algorithm>
#include <array>
#include <chrono>
#include <iostream>
#include <random>
#include <stdexcept>
#include <string>
#include <vector>
#pragma comment(lib, "Ws2_32.lib")

struct GameResult
{
    int firstScore = 0;
    int secondScore = 0;
    int winner = 0;
    double seconds = 0;
};

inline void SendLine(SOCKET socket, const std::string& text)
{
    std::string data = text + "\n";
    int position = 0;
    while (position < static_cast<int>(data.size()))
    {
        int count = send(socket, data.data() + position, static_cast<int>(data.size()) - position, 0);
        if (count <= 0) throw std::runtime_error("Соединение потеряно при отправке");
        position += count;
    }
}

inline std::string ReadLine(SOCKET socket)
{
    std::string text;
    char symbol;
    while (true)
    {
        int count = recv(socket, &symbol, 1, 0);
        if (count <= 0) throw std::runtime_error("Другой игрок отключился");
        if (symbol == '\n') return text;
        if (symbol != '\r') text += symbol;
    }
}

inline std::string Input(const std::string& prompt)
{
    std::cout << prompt << std::flush;
    std::string text;
    if (!std::getline(std::cin, text)) throw std::runtime_error("Ввод завершён");
    return text;
}

inline int ReadNumber(const std::string& prompt, int minimum, int maximum)
{
    while (true)
    {
        std::string text = Input(prompt);
        try
        {
            size_t end;
            int value = std::stoi(text, &end);
            if (end == text.size() && value >= minimum && value <= maximum) return value;
        }
        catch (const std::exception&) { }
        std::cout << "Введите число от " << minimum << " до " << maximum << ".\n";
    }
}

inline std::string Figure(int move)
{
    const std::array<std::string, 5> names = { "Камень", "Ножницы", "Бумага", "Предложение ничьей", "Поражение" };
    if (move < 1 || move > 5) throw std::runtime_error("Неверный ход от соперника");
    return names[move - 1];
}

inline int RoundWinner(int first, int second)
{
    if (first == second) return 0;
    return (first == 1 && second == 2) || (first == 2 && second == 3) || (first == 3 && second == 1) ? 1 : 2;
}

inline std::string WinnerText(int winner)
{
    if (winner == 0) return "Ничья";
    return "Победил игрок " + std::to_string(winner);
}

inline std::string ModeText(int mode)
{
    if (mode == 1) return "Человек - компьютер (игрок 1: компьютер, игрок 2: человек)";
    if (mode == 2) return "Компьютер - компьютер";
    return "Человек - человек";
}

inline int ChooseMove(bool computer, std::mt19937& random)
{
    if (computer) return std::uniform_int_distribution<int>(1, 3)(random);
    return ReadNumber("Ваш ход: 1 - камень, 2 - ножницы, 3 - бумага, 4 - предложить ничью, 5 - признать поражение: ", 1, 5);
}

inline void Play(SOCKET socket, bool server, int mode, int games)
{
    int player = server ? 1 : 2;
    bool computer = mode == 2 || (mode == 1 && server);
    std::cout << "Режим: " << ModeText(mode) << "\nВы - игрок " << player << ". Игр в матче: " << games << "\n";
    std::mt19937 random(std::random_device{}());
    std::array<int, 3> figures = { 0, 0, 0 };
    std::vector<GameResult> results;
    int firstWins = 0;
    int secondWins = 0;

    for (int game = 1; game <= games; game++)
    {
        GameResult result;
        bool ended = false;
        auto start = std::chrono::steady_clock::now();
        std::cout << "\nИгра " << game << " из " << games << ", 5 раундов.\n";
        for (int round = 1; round <= 5;)
        {
            std::cout << "Раунд " << round << ". Счёт: " << result.firstScore << ":" << result.secondScore << "\n";
            int local = ChooseMove(computer, random);
            // Каждый отправляет свой выбор до получения выбора соперника.
            SendLine(socket, std::to_string(local));
            int remote = std::stoi(ReadLine(socket));
            Figure(remote);
            int first = server ? local : remote;
            int second = server ? remote : local;
            std::cout << "Игрок 1: " << Figure(first) << "; игрок 2: " << Figure(second) << "\n";

            // Ответ на предложение ничьей отправляется отдельно от выбора хода.
            bool accept = remote == 4 && (local == 4 || computer);
            if (remote == 4 && !computer && local != 4 && local != 5)
                accept = ReadNumber("Соперник предлагает ничью. 1 - принять, 0 - отказаться: ", 0, 1) == 1;
            SendLine(socket, accept ? "1" : "0");
            bool remoteAccept = ReadLine(socket) == "1";
            bool draw = (local == 4 && remoteAccept) || (remote == 4 && accept);
            if (local == 5 || remote == 5 || draw)
            {
                if (first == 5 && second == 5) result.winner = 0;
                else if (first == 5) result.winner = 2;
                else if (second == 5) result.winner = 1;
                else result.winner = 0;
                std::cout << "Игра завершена досрочно. " << WinnerText(result.winner) << "\n";
                ended = true;
                break;
            }
            if (local == 4 || remote == 4)
            {
                std::cout << "Предложение ничьей отклонено. Выберите ход заново.\n";
                continue;
            }

            figures[first - 1]++;
            figures[second - 1]++;
            int winner = RoundWinner(first, second);
            if (winner == 1) result.firstScore++;
            if (winner == 2) result.secondScore++;
            std::cout << "Итог раунда " << round << ": " << WinnerText(winner)
                      << ". Счёт: " << result.firstScore << ":" << result.secondScore << "\n";
            round++;
        }
        if (!ended)
            result.winner = result.firstScore == result.secondScore ? 0 : result.firstScore > result.secondScore ? 1 : 2;
        // Оба экрана показывают одну длительность, измеренную сервером.
        if (server)
        {
            result.seconds = static_cast<double>(std::chrono::duration_cast<std::chrono::milliseconds>(
                std::chrono::steady_clock::now() - start).count()) / 1000.0;
            SendLine(socket, std::to_string(result.seconds));
        }
        else result.seconds = std::stod(ReadLine(socket));
        results.push_back(result);
        if (result.winner == 1) firstWins++;
        if (result.winner == 2) secondWins++;
        std::cout << "Итог игры " << game << ": " << WinnerText(result.winner)
                  << "; счёт " << result.firstScore << ":" << result.secondScore
                  << "; длительность " << result.seconds << " сек.\n";
    }

    std::cout << "\nСтатистика матча:\n";
    for (size_t i = 0; i < results.size(); i++)
        std::cout << "Игра " << i + 1 << ": " << WinnerText(results[i].winner) << "\n";
    int winner = firstWins == secondWins ? 0 : firstWins > secondWins ? 1 : 2;
    std::cout << "Итог матча: " << WinnerText(winner) << "; победы " << firstWins << ":" << secondWins << "\n";
    int total = figures[0] + figures[1] + figures[2];
    if (total == 0) std::cout << "Завершённых раундов с фигурами нет.\n";
    else
    {
        int maximum = *std::max_element(figures.begin(), figures.end());
        int minimum = *std::min_element(figures.begin(), figures.end());
        std::cout << "Самая популярная фигура: ";
        for (int i = 0; i < 3; i++) if (figures[i] == maximum) std::cout << Figure(i + 1) << " (" << figures[i] << ") ";
        std::cout << "\nСамая непопулярная фигура: ";
        for (int i = 0; i < 3; i++) if (figures[i] == minimum) std::cout << Figure(i + 1) << " (" << figures[i] << ") ";
        std::cout << "\n";
    }
}

inline int Run(bool server, int argc, char* argv[])
{
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    WSADATA data;
    if (WSAStartup(MAKEWORD(2, 2), &data) != 0) return 1;
    SOCKET listener = INVALID_SOCKET;
    SOCKET connection = INVALID_SOCKET;
    int exitCode = 0;
    try
    {
        // Аргументы позволяют запускать автоматические проверки без ручного ввода.
        int port = argc > 1 ? std::stoi(argv[1]) : ReadNumber("Порт (например 5104): ", 1, 65535);
        if (port < 1 || port > 65535) throw std::runtime_error("Неверный порт");
        int mode;
        int games;
        if (server)
        {
            mode = argc > 2 ? std::stoi(argv[2]) : ReadNumber("Режим: 1 - человек-компьютер, 2 - компьютер-компьютер, 3 - человек-человек: ", 1, 3);
            games = argc > 3 ? std::stoi(argv[3]) : ReadNumber("Количество игр в матче: ", 1, 100);
            if (mode < 1 || mode > 3 || games < 1 || games > 100) throw std::runtime_error("Неверные настройки матча");
            listener = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
            if (listener == INVALID_SOCKET) throw std::runtime_error("Не удалось создать сокет");
            sockaddr_in address{};
            address.sin_family = AF_INET;
            address.sin_port = htons(static_cast<u_short>(port));
            address.sin_addr.s_addr = htonl(INADDR_ANY);
            if (bind(listener, reinterpret_cast<sockaddr*>(&address), sizeof(address)) == SOCKET_ERROR || listen(listener, 1) == SOCKET_ERROR)
                throw std::runtime_error("Не удалось запустить сервер. Возможно, порт занят.");
            std::cout << "Ожидание клиента на порту " << port << "...\n" << std::flush;
            connection = accept(listener, nullptr, nullptr);
            if (connection == INVALID_SOCKET) throw std::runtime_error("Ошибка подключения");
            SendLine(connection, std::to_string(mode));
            SendLine(connection, std::to_string(games));
        }
        else
        {
            std::string host = argc > 2 ? argv[2] : Input("IP сервера (на этом компьютере 127.0.0.1): ");
            sockaddr_in address{};
            address.sin_family = AF_INET;
            address.sin_port = htons(static_cast<u_short>(port));
            if (inet_pton(AF_INET, host.c_str(), &address.sin_addr) != 1) throw std::runtime_error("Неверный IP-адрес");
            connection = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
            if (connection == INVALID_SOCKET || connect(connection, reinterpret_cast<sockaddr*>(&address), sizeof(address)) == SOCKET_ERROR)
                throw std::runtime_error("Не удалось подключиться к серверу");
            mode = std::stoi(ReadLine(connection));
            games = std::stoi(ReadLine(connection));
        }
        Play(connection, server, mode, games);
    }
    catch (const std::exception& error)
    {
        std::cerr << "Ошибка: " << error.what() << "\n";
        exitCode = 1;
    }
    if (connection != INVALID_SOCKET) closesocket(connection);
    if (listener != INVALID_SOCKET) closesocket(listener);
    WSACleanup();
    std::cout << "Соединение закрыто.\n";
    if (argc == 1)
    {
        std::cout << "Нажмите Enter для выхода.";
        std::string line;
        std::getline(std::cin, line);
    }
    return exitCode;
}
