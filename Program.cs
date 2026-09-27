using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;


namespace ConsoleApp1
{
    class KosmoBot
    {

        static async Task Main(string[] args)   // ← Main теперь async Task
        {
            var client = new TelegramBotClient("Your_Token_Bot");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            client.StartReceiving(
                updateHandler: Update,
                errorHandler: Error,
                receiverOptions: receiverOptions
            );

            // Проверяем, что бот реально вышел на связь с Telegram
            var me = await client.GetMe();
            Console.WriteLine($"Бот @{me.Username} запущен. Нажмите Enter для выхода.");

            Console.ReadLine();
        }

        async static Task Error(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken token)
        {

        }

        


        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {

            string[] ssilkiSHPK =
            {
                "https://telegra.ph/Muzej-kosmosa-12-06", // Музей космоса
                "https://telegra.ph/SHtab-podgotovki-v-kosmonavty-04-16-3", // Лего Музей
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-15", // микроскопы
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-16", // липка
                "https://telegra.ph/SHtab-podgotovki-v-kosmonavty-04-16-2",// сони икспериа тач
                "https://telegra.ph/SHtab-podgotovki-v-kosmonavty-04-16",// 3д-принтер
                "https://telegra.ph/SHtab-Podgotovki-Kosmonavtov-04-19-2",// Сокол Тысячилетия
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-19-3",// Бейби Йода
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-19-4",// Р2Д2
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-20-3",// Марсинатор
                "https://telegra.ph/Otkrytyj-kosmos-09-09",// Левитация
            }; //11 (0 - 10)
            string[] ssilkiMKC =
           {
                "https://telegra.ph/SHtab-podgotovki-kosmonavtov-04-19",             // Перчатки космонавта
                "https://telegra.ph/Mezhdunarodnaya-Kosmicheskaya-Stanciya-04-21",   // Станция МКС
                "https://telegra.ph/Mezhdunarodnaya-Kosmicheskaya-Stanciya-04-22",   // Интерактивная Песочница
                "https://telegra.ph/Mezhdunarodnaya-Kosmicheskaya-Stanciya-04-22-3", // Вортекс
                "https://telegra.ph/Otkrytyj-kosmos-04-16-2",                        // Космические весы
                "https://telegra.ph/Prishelec-ZHorik-09-09",                         // Инопланетянин Жорик
                "https://telegra.ph/Otkrytyj-kosmos-04-23-11",                       // Плей Рум
                "https://telegra.ph/Fotozona-Medvedicy-09-09",                       // Созвездие медведицы    
            }; //8 (0 - 7)
            string[] ssilkiOK =
           {
                "https://telegra.ph/Otkrytyj-kosmos-04-23-5",             // Фотозона Неон  
                "https://www.youtube.com/watch?v=EIEOGoBA4FA",   // Визуализация гравитации
                "https://telegra.ph/Otkrytyj-kosmos-04-16",   // Гравитация Юпитера  
                "https://telegra.ph/Plazma-komnata-09-09", // Плазма комната  
                "https://telegra.ph/Otkrytyj-kosmos-04-23-7",                        // Маятник Фуко      
                "https://Ssilka-na-vihr",                         // Вихрь
                "https://ssilka-na-tri-teni",                       // Три тени      
            }; //7 (0 - 6)
            string[] ssilkiMedia =
            {
                "https://lh3.googleusercontent.com/fife/ALs6j_FekA_HwWZNyCZFdRCXNt3GW4JO0ih6UOGM2iPE5Bv4Y70Zmx_uUiPRW95pfLPHCUHMSbYZHaG13RSr5VBA2woQhue8cfYSC2_i3zI36sL9VBPfv6vqN29sGv9N8f2jy6z6fKLLYGhblgegRPaFjThL2NXDDnppMDJJWrdt6gO6Q6c3JvcWlS8Ti--y1jiydftXnw1jmLgdtdQ_o3UL_M2HutyHMRITQCK1VsYKQ0iF5xZaHDaMflAhuEElejNV3ui4_S8OEV_buqngmNHQTjrZUvMUVXfYYfOEfdskkxcoZrqEDDZG2T8zbG8uQJRU2605pDRGEI3rCZVPzjMZnjNrIi3lr74Fzd7WTt1fiRH70CHjSdrSVbT62x_BkK1Ovq2ph0AeF84yHLgKAY2-qbyvE3GgxJ3Ml4SlmM_eEuD6hI65DzuZzTtiAIufm01CQ_3Tx7-4L4LeEMUsi6XBBpoQSllIL8qt8pFvRykhfP_ciaKoxEF72byLWfXoXD1fR6PGJh1-av8Z0GdEIeIZVHDxG8BYc4EqkVk82h5RWoDHybOVdlhH1uXM7E_2xhvbFuNBZofmsbWab-cCmJlC1q6h43bkrgZeQudbLS7z3_ajoJ6qZtWuI9X-L8JXYN6EBMgMIcZsCvGkcyx0GBHWYSCS3Ahb9LpTqr2PhrFc_E2oa2PwEsjJjcTsPBK5Tx0p0b_Rx7rJFQ5MNwUDcIsF5ApWixzkUBGBujdJMBzkg3SsHQFab2AyQ9jPb323gB1sHitShrxcD-fJE-Um0V0IRH-f-7XVyR2zMybKDr50OzmcNMRwwNH4aWznGoGSBQxz9CAsoZrzevqJ8lmYGAMWc3T3_3Xqaf7sDWJp9Td2N19Wv1--Mi-fo2VCcvWKejY-PQit9GDZLHJlX7fP5pMOA4908KjEGJVGq7SLfPxsXvYVOhlAsbT5FnqkirFkwC-zbx6TIRl489_WqYWoFCBgShdChFVKDTGfnjpc-ZJGJGCy2hj2AIgFd43BE3daBe4eGqa071TEYkScp0KQE0Lp9p_Dx3a_E8j2GfbbfnsGxjDnZCvQvkBig4Qrj0P4Na3fxt1JxJsqy9Syu3A2R7yj7k9dN-QU3sCAHBHPXnquhTXgRaN22VyNCLaUyrYyRVWwnvUi91jpeY33phvBa3JyHEpFWn9u04Y8HFi_lbXkyaPgLQizUG9yTdVp_lg9vtaejmMmnKW5WqnxtMYkO9FbG91-dyMK2Xl0GhJ3qVs7Yhu_6dYLL5wdjRPsUQGut2R4fdRktbIUKT44Ax0hnIWOCqYKgZvOSPTtvfZWlL6MzqC1TIlHuXlwNkg-_KkjOvb1DM9KArbO9D_c5DraXrhMEpszIPl5-cvBuE3ucbsN_Uey6PyW5qH-7kIwrI7Vq4NEJ-Oxap3mYhxHRcWf2nJt7EUfgo2Fd4oE63SogYOqvfo2FWkScP7M9CsF4Q5NkH5MiBPFn4O4R3fd_8TD2cehuMtA9Qk42HXRFCyxmPvSXixiUTYIhE2WjhnUQSggXaDeEPggCi5Oe-8e3ISmbTgIYi8kiD-gEw6RJuMNeiIOAkJPudFqIdMR0w9VkBWBHN1mDJoEhknI9yqiFdZ6wDSuamv3XGpwi8ascUJ9Kg=w1920-h970?auditContext=prefetch", // Tri Teni
                "https://lh3.googleusercontent.com/fife/ALs6j_F2wnuWlMmSyHYxxRd1xcT0MtBR1I2jRczIdoMxXlKKDZJeD3mhz0d6cJ7aLQLj9XC_Cd48IBnXj5wfTwd2gQx3GZ_xI8Zn2YpM5VoyKrC2NQWJvBPuD8I-Nc2ugP_8zMW9ZrVwBOm0cJyK8jPjfA0OfO0rzZemeux_xGiAKQ2iEuAtpsHbfStbk9pJp4NZx7NopGYn0W46JVcPtIMmjmryikFNUJ11WZ9ZNkmuRkxnINqcACaZA222e1wu4BN_BshntdlhgHpsdV4Byr7KgmmCQfs419uvC1xsAuwPDYUnJsZPAlwa3q9ockJnmW3qk_LdmOYpRFqG0sdDxuJM3URsr6tvWdIqljLx3XN80nWC7_ljzi-RdGRDXxanjU4UL1LVRxVfM3VOhMG3gD_KXFKkfKo4j3S0eBlJZCMOR_8K2dzKc-aIZADVR4_jUc6UlfekFO10wm7rOahhcoIuYKALAwlYUtC4a5tUDe-uaPNzWCMH6HvB3WHi8Dcji8LQrHYuxKTPT9cvNzyRjBXOrgz-BUvdC_heTXfMwMCblh5II_nwdo9pJ6pm2GtpbnZNT2W7Hw3w-r87KryTOn9IDI3ribvd1nWJtoZLdB7QNhcNTFVy_yQ9IW_phfGTrlJCFSHabwF7UE1jgFr6vII7zlS5eqJLaF5Uwpf0XqOUUN2ei5TmuFNknXYkMx3uehmDvfmof1Jo5e5m_GtvGwT5em7Vutao76m3W9pAeFypNq7wJFfczeGK9zuRTpkB3IKKMS9nWW6EoMy_57NdMOjCfI_ktBSb2RwL6t3d2kjQKyw6aeDFFOnvY6BMM9jVNXxggcxhvKv5cSjvLHC8ged_r4xiRF90NVsmIwK3PBGV1JORD3AVDp5xTOMdkh_Z4Vb_A_n4GlGgGLuO67b1DDPwWM0joOg_JRMHl-yPPNVMG4jjRyRa7CsHHDU-bNMQcUmJkwWxWnoo7qeca7Xc3ATeEhDOi7e1MPBGmMyN_bl0E9hElTme7LrHYswsXfLmfWnRK8t8Wl1tec17ZsbReBhpeOUwZcUbMHKoUlrVmSecy_KOKHmUM68TJrlu2RpAghpztT4GKnIGMvwVe8MEjlFfGpR_yRv49iMinuMR5cmNU69Jo6cSFwU1pzpYW3c9SCF8LL8WBf45RGQLoFim5evlw2sWtnNb9ue7NRKbt0o8zPn00lc6mi03n2kW_VbWgBYrUnW6aFW18Cue0lp4bIEXf-OqWRQ0GGgKVYNZVIUeOOXg4tPebqz_Effz2g1CFDCVZijNZgUaFY4fHlFSMGUz4MyyyEu-oUfTr1a6YHCIg4b_TcSuXCWQImhQ_yj_biZrna_i5ftNMKTSaW-BP-5ClseloRhXW-ErJ27yDYc4Djbt0GQ7sdz0t-tlGEpECtypOJsAkJm1UT3lZ_ixIfaVq-Hzi0iVhhdHHSOvZXaCQLrH8Iaamsu7G1seLvPXqi33-RQYiqHLniDwVTgMEEEXfyAcA9ia9oCHy9pKwx6-hiMHvJvYvnGmjkrXr2h0XKNJZmFmg9LlaBxYzNKasyuHDEDI_3-7B2yOxg1n9YSdMeGDWpqvyj4ztwSE04RR-gRZr-r72FP9ZFs0Xf26Fu3YqKdeJYRZDBeXf9heHw=w1920-h970?auditContext=prefetch", // Vihr


            }; // В целом любые фотки и видосики, хранящиеся на гугл диске: "https://drive.google.com/drive/folders/1C2mTr_pbjkLzYmBzWHNvwrjyh8Uts530?hl=ru"
            string ssilkaMK = "https://drive.google.com/file/d/1IhKTjO6GhXI4G0xLNOBN_nYdHp0w7wCQ/view?usp=drive_link";
            string[] ssilkiTB =
            {
                "https://drive.google.com/file/d/1M1Tz-3PEEGgzeU0pbHKKUPtMWWY1W5mD/view?usp=drive_link",// Van-de-Graf,
                "https://drive.google.com/file/d/1djbb5T1530t4jydnanotEvFGurKGEwxt/view?usp=drive_link", // Tesla-podium
                "https://drive.google.com/file/d/1VoOe1hGjctRZDt-xk_VUY71WfTLZLkpq/view?usp=drive_link" //Giroskop
            };
            string[] ssilkiVR =
            {
                "https://drive.google.com/u/0/drive-usercontent/1X3QjyC95sGPo2R3mdtF3rPzfxOEmj_rv=w275-h261-p-k-rw-v1-nu-iv1", // Farpoint Gun
                "https://drive.google.com/u/0/drive-usercontent/1cM87Sixcszx9t8kx0p0mSGHDeXObbIzG=w275-h261-p-k-rw-v1-nu-iv1", // Farpoint VR
                "https://drive.google.com/u/0/drive-usercontent/1qcHSUvvVmjTsquJ91YBn6Oxw1vSe0DGf=w275-h261-p-k-rw-v1-nu-iv1", // Stardust Pad
                "https://drive.google.com/u/0/drive-usercontent/12fYiA7vMPQsJCUMz4eoCVhs97YOg8JCM=w275-h261-p-k-rw-v1-nu-iv1", // BeatSaber1
                "https://drive.google.com/u/0/drive-usercontent/12fYiA7vMPQsJCUMz4eoCVhs97YOg8JCM=w275-h261-p-k-rw-v1-nu-iv1", // BeatSaber2
                "https://drive.google.com/u/0/drive-usercontent/1akhA0WgAgMMwh9jBq3G4qF1fmyy_hmle=w275-h261-p-k-rw-v1-nu-iv1", // MissionISS
                "https://drive.google.com/u/0/drive-usercontent/1akhA0WgAgMMwh9jBq3G4qF1fmyy_hmle=w275-h261-p-k-rw-v1-nu-iv1", // Space Pirates
                "https://drive.google.com/u/0/drive-usercontent/1GctpoP0P6j-FG4A2e-bsdcV2twQbzhNo=w275-h261-p-k-rw-v1-nu-iv1", // Общая инфо1
                "https://drive.google.com/u/0/drive-usercontent/1j4CUhkPDZphjIZEaCVAXVynZc0p7VsV9=w275-h261-p-k-rw-v1-nu-iv1", // Общая инфо2
                
            }; //9 (0 - 8)



            var message = update.Message;


            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName}    |    {message.Text}");

                if (message.Text == "/start")
                {

                    var sent = await botClient.SendMessage(message.Chat.Id, "Добро пожаловать в KosmoSchool, \n \n Бот был сделан персональщиком, который к сожалению покинул нашу компанию, но всегда хотел сделать работу для инструкторов в удовольствие. IlyaIlyich с Космо3", replyMarkup: new string[] { "Start" });
                } //Самый первый запуск
                if (message.Text == "Start")
                {

                    var sent = await botClient.SendMessage(message.Chat.Id, "О чём тебе нужно узнать", replyMarkup: new string[] { "О зонах" });
                }  // Выход в меню, кнопки: О зонах,
                if (message.Text == "О зонах")
                {
                    var sent = await botClient.SendMessage(message.Chat.Id, "Хорошо, вот информация о зонах", replyMarkup: new string[] { "Menu" });

                    var messagey = await botClient.SendMessage(message.Chat.Id, "/Kacca \n /Openspace (Открытый космос) \n /SHPK (Штаб подготовки космонавтов \n /MKC (международная космическая станция)\n /p Переходящие зоны(МКС и Открый космос) \n /Giroskop \n /MK (мастер классы)\n /VR \n /Tecla-шоу");

                }// Выбор Зоны
                if (message.Text == "Menu")
                {

                    var sent = await botClient.SendMessage(message.Chat.Id, "О чём тебе нужно узнать", replyMarkup: new string[] { "О зонах" });
                }


                if (message.Text == "/Kacca")
                {
                    var messageyy = await botClient.SendMessage(message.Chat.Id, "Данная зона, обучается непосредственно на выставке с администратором");
                }



                if (message.Text == "/SHPK")
                {
                    var messageyy = await botClient.SendMessage(message.Chat.Id, "Данная зона, одна из первых на нашей выставке, " +
                        "здесь мы знакомим наших посетителей с первыми шагами в космическую историю." +
                        " Перед выходом в следующие зоны космоса, " +
                        "каждый должен пройти подготовку юного космонавта на данной локации, " +
                        "здесь всех будет ждать космический музей (с настоящими экспонатами из обихода космонавтов), " +
                        "гироскопы (которые помогают испытать ваш вестибулярный аппарат и подготовить к выходу в космос)," +
                        " история о космосе, фотозоны и многое другое.\n \n В зоне ШПК есть 11 зон: \n " +
                               "/1_1  Музей космоса\n" +
                               " /1_2  Лего Музей\n" +
                               " /1_3  микроскопы\n" +
                               " /1_4  липка\n" +
                               " /1_5  сони икспериа тач\n" +
                               " /1_6  3д-принтер\n" +
                               " /1_7  Сокол Тысячилетия\n" +
                               " /1_8  Бейби Йода\n" +
                               " /1_9  Р2Д2\n" +
                               " /1_10 Марсинатор\n" +
                               " /1_11 Левитация\n" +
                               "Отправьте в чат номер нообходимого экспоната, НАЖАВ НА НЕГО!");
                }
                if (message.Text == "/1_1")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на музей космоса",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Музей космоса", ssilkiSHPK[0]));
                } // Muzei kosmosa
                if (message.Text == "/1_2")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Лего Музей",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Лего Музей", ssilkiSHPK[1]));
                } // Lego-Muzei
                if (message.Text == "/1_3")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Микроскопы",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Микроскопы", ssilkiSHPK[2]));
                } // Mikrosopi
                if (message.Text == "/1_4")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Липку",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Липка", ssilkiSHPK[3]));
                } //LeapMOtion
                if (message.Text == "/1_5")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Sony Experia",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Sony Experia", ssilkiSHPK[4]));
                } // Soni Experia
                if (message.Text == "/1_6")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на 3D-принтер",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("3D-принтер", ssilkiSHPK[5]));
                } // 3d-printer
                if (message.Text == "/1_7")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Сокол Тысчячилетия",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Сокол Тысчячилетия", ssilkiSHPK[6]));

                } // Sokol Tisyachiletia
                if (message.Text == "/1_8")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Грогу",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Грогу", ssilkiSHPK[7]));
                } // Grogu
                if (message.Text == "/1_9")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Р2Д2",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Р2Д2", ssilkiSHPK[8]));
                } // R2D2
                if (message.Text == "/1_10")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Марсинатор",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Марсинатор", ssilkiSHPK[9]));
                } // Marsinator
                if (message.Text == "/1_11")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Левитацию",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Левитация", ssilkiSHPK[10]));
                } // Levitacia
                if (message.Text == "/MKC")
                {
                    var messageyy = await botClient.SendMessage(message.Chat.Id, "Это переходная зона от ШПК в Открытый космос. " +
                        "Здесь посетители могут посмотреть на землю в иллюминаторе с кусочка МКС," +
                        " попробовать работу в космических перчатках, " +
                        "поиграть в игры и многое другое." +
                        "\n \n В зоне МКС есть 4 зон: \n " +
                               " /2_1  Перчатки космонавта  \n" +
                               " /2_2  Станция МКС/Touch панель  \n" +
                               "Отправьте в чат номер нообходимого экспоната, НАЖАВ НА НЕГО!");
                }
                if (message.Text == "/2_1")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на перчатки космонавта",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Перчатки космонавта", ssilkiMKC[0]));
                } // PErchatki Kosmonavta
                if (message.Text == "/2_2")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Станцию МКС",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Станция МКС", ssilkiMKC[1]));
                } // Stancia MKS
                if (message.Text == "/Openspace")
                {
                    var messageyy = await botClient.SendMessage(message.Chat.Id, "Данная зона, самая большая часть выставки, " +
                        "здесь каждый сможет полностью погрузиться" +
                        " в тематику и ритм космоса." +
                        "\n \n В зоне Открытого космоса есть 11 зон: \n" +
                               //              " /3_1  Фотозона неон  \n" +
                               " /3_1  Гравитация Юпитера  \n" +
                               " /3_2  Плазма-Комната \n" +
                               " /3_3  Фотозона Трени тени  \n" +
                               " /3_4  Визуализация гравитации\n" +
                               " /3_5  ШадоуСтопер   \n" +
                               "Отправьте в чат номер нообходимого экспоната, НАЖАВ НА НЕГО!");
                }
                if (message.Text == "/3_1")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Гравитацию Юпитера",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Гравитация Юпитера", ssilkiOK[2]));
                } // Upiter
                if (message.Text == "/3_2")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Плазма-комнату",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Плазма-Комната", ssilkiOK[3]));
                } // Plazma-Komnata
                if (message.Text == "/3_3")
                {
                    var messages = await botClient.SendPhoto(message.Chat.Id, ssilkiMedia[0]);
                } // Tri Teni
                if (message.Text == "/3_4")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Визуализацию гравитации",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Визуализация гравитации", ssilkiOK[1]));
                } // Vizualizacia Graviracii
                if (message.Text == "/3_5")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе скрипт на ShadowStoper:\n\n" +
                        "\r\n*Shadowstopper - Генератор, или Космический Ловец Теней.*\r\n\r\nС помощью этого устройства вы можете остановить свою тень на время и посмотреть на себя со стороны. Для этого нужно лишь выбрать интересную позу, встать в нее и замереть на несколько мгновений. После активации устройства произойдет большая вспышка света, которая оставит ваш силуэт на стене. Ну что, попробуем оставить след в истории?\r\n\r\n*Страна происхождения:* Космос\r\n\r\n*Интересные факты:*\r\n\r\n1. Тень — это темный силуэт человека, возникающий, когда объект или человек препятствуют свету, исходящему от источника света.\r\n2. Слово «умбра» происходит от латинского слова «тень». Умбра относится к самой внутренней области тени, которая кажется самой темной.\r\n3. До изобретения механических часов люди пользовались в основном солнечными часами. В простейшем случае они представляли собой гномон — вкопанный в землю шест, солнечная тень от которого указывала на текущее время.");
                } // ShadowStoper 


                if (message.Text == "/p")
                {
                    var messageyy = await botClient.SendMessage(message.Chat.Id, "Это дополнительные экспонаты, которые странствуют из зоны в зону: \n \n" +
                               "/3_11  Космо весы\n" +
                               " /3_5  маятник Фуко\n" +
                               " /3_8  Жорик\n" +
                               " /3_10  Медведицы\n" +
                               " /2_3  Фотозона неон\n" +
                               " /2_4  Вортекс\n" +
                               " /2_9  Песочница\n" +
                               " /2_5  Плейрум\n" +
                               " /2_6  Вихрь\n" +
                               "Отправьте в чат номер нообходимого экспоната, НАЖАВ НА НЕГО!");
                }

                if (message.Text == "/3_11")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Космические весы",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Космические весы", ssilkiMKC[4]));
                } // Kosmo Vesi                           
                if (message.Text == "/3_5")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Маятник Фуко",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Маятник Фуко", ssilkiOK[4]));
                } // Maytnik Fuko              
                if (message.Text == "/3_8")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Георгия Космического",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Жорик", ssilkiMKC[5]));
                } // Gorik
               
                if (message.Text == "/3_10")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Созвездие медведицы",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Зозвездие медведицы", ssilkiMKC[7]));
                } // Medvdedici
                if (message.Text == "/2_3")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Фотозону Неон",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Фотозона Неон", ssilkiOK[0]));
                } // Fotozona Neon
                if (message.Text == "/2_4")
                 {
                     var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Vortex",
                          ParseMode.Html,
                          protectContent: true,
                          replyParameters: update.Message.Id,
                          replyMarkup: new InlineKeyboardButton("Vortex", ssilkiMKC[3]));
                 } // Vortex*/ // Vortex
                if (message.Text == "/2_9")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Интерактивную песочницу",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Интерактивная песочница", ssilkiMKC[2]));
                } // Interaktivnaya Pesochnica
                if (message.Text == "/2_5")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Play Room",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Play Room", ssilkiMKC[6]));
                } // Play Room
                if (message.Text == "/2_6")
                {
                    await botClient.SendPhoto(message.Chat.Id, ssilkiMedia[1]);
                } //Vihr









                if (message.Text == "/MK")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот тебе ссылка на Мастер классы, " +
                        "скоро в боте появятся на них видосики, но пока мы их не сняли. " +
                        "Списрк мастер-классов ниже:\n\n" +
                        " 1. /3D-ручка  \n" +
                        " 2. /Bombochka для ванны\n" +
                        " 3. /Kocmoc в пробирке\n" +
                        " 4. /Kocmo-мыло\n" +
                        " 5. /Peakmop Железного Человека\n" +
                        " 6. /Mech Джедайский Световой\n" +
                        " 7. /Kosmoslime\n" +
                        " 8. /Bзлem ракеты\n" +
                        " 9. /CBETILNIK-Planeta\n");
                    var messageys = await botClient.SendMessage(message.Chat.Id, "Вот твоя ссылка на Зону мастер-классов",
                        ParseMode.Html,
                        protectContent: true,
                        replyParameters: update.Message.Id,
                        replyMarkup: new InlineKeyboardButton("Мастер-классы", ssilkaMK));

                }

                if (message.Text == "/Giroskop")
                {
                    var messagey = await botClient.SendMessage(message.Chat.Id, "Вот техника безопасности на гироскоп",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Гироскоп", ssilkiTB[2]));
                }





                if (message.Text == "/VR")
                {

                    var sent = await botClient.SendMessage(message.Chat.Id, "VR обучает непосредственно Инженер.\n", replyMarkup: new string[][]
                        {
                            ["/Farpoint", "/Stardust", "/BeatSaber"],
                            ["/MissionISS", "/SpacePirates", "Menu"] 
                        }
                    
                    );

                    var messages = await botClient.SendMessage(message.Chat.Id,"Если есть желание обучиться, напиши об этом администратору, он скажет когда приходить.\n\n" +

                    "На VR есть 2 зоны: <b>платная</b> и <b>бесплатная</b>\n\n" +

                    "В бесплатную зону входит:\n" +
                    "• /Farpoint\n" +
                    "• /Stardust\n\n" +

                    "В платную зону входит:\n" +
                    "• /BeatSaber\n" +
                    "• /MissionISS\n" +
                    "• /SpacePirates",
                        ParseMode.Html,
                        protectContent: true);

                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[7]);

                    messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[8]);

                    var messagess = await botClient.SendMessage(message.Chat.Id, "Колесо регулировки крутится в обе стороны:\n" +
                           "• Против часовой стрелки — растянуть\n" +
                           "• По часовой стрелке — затянуть\n\n" +

                           "Кнопка включения используется, если:\n" +
                           "• Черный экран\n" +
                           "• В подобных случаях\n\n" +

                           "Аккумулятор необходимо заменять, когда:\n" +
                           "• На нем остается одна точка индикации",
                        ParseMode.Html,
                        protectContent: true);



                }

                if (message.Text == "/Farpoint")
                {
                    var messages = await botClient.SendMessage(message.Chat.Id, "FarPoitn - Увлекательная стрелялка по паукам!* 🕷️\n\n" +
                    "Зачищайте разные локации от монстров, метко стреляя в них.\n\n\n\n\n\n" +
                    "🎮 Управление:\n\n",
                        ParseMode.Html,
                        protectContent: true); // описание 

                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[0]); // фото пада-автомата

                     messages = await botClient.SendMessage(message.Chat.Id,"• *Настройка камеры:* Используйте, когда камера в игре находится не в нужном месте.\n" +
                    "• *Включение джойстика:* Нажмите эту клавишу на 10 секунд, чтобы *выключить* джойстик. Короткое нажатие — *включить*.\n" + // Уточнено описание
                    "• *Отмена действия:* Нажмите, чтобы выйти из ненужного меню или опции.\n" +
                    "• Остальные клавиши интуитивно понятны.\n\n",
                        ParseMode.Html,
                        protectContent: true); // управление

                     messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[1]); // фото vr-шлема



                    messages = await botClient.SendMessage(message.Chat.Id, "🥽 *VR шлем:*\n\n" +
                    "1️⃣ Нажмите колесо разрегулировки и, растягивая шлем, наденьте его на голову ребенка.\n" +
                    "2️⃣ Подтяните очки, чтобы они сидели плотно, но не сдавливали голову.\n" +
                    "3️⃣ Крутите колесо подзатяжки *строго по часовой стрелке*.",
                        ParseMode.Html,
                        protectContent: true);
                }

                if (message.Text == "/Stardust")
                {
                    var messages = await botClient.SendMessage(message.Chat.Id, "PS4 Stardust\n\n\n\n" +
                          "🌌 Защитите планету от каменного дождя из космоса!\n\n" +
                          "Бороздите атмосферу планеты и разбивайте огромные каменные глыбы лазером, бомбами и другим интересным вооружением. 🚀",
                        ParseMode.Html,
                        protectContent: true);


                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[2]);


                     messages = await botClient.SendMessage(message.Chat.Id, "*Запуск игры:*\n\n" +
                             "Для запуска игры нажмите кнопку \"Продолжить\" в главном меню несколько раз. " +
                             "Настройки по умолчанию менять не нужно.",
                        ParseMode.Html,
                        protectContent: true);
                }

                if (message.Text == "/BeatSaber")   
                {
                    var messages = await botClient.SendMessage(message.Chat.Id, "*Beat Saber 🎵*\n\n" +
                           "С этой игры мы переходим от PS к Oculus.\n\n" +
                           "Разбивайте кубы под музыку виртуальными мечами! ⚔️\n\n",
                        ParseMode.Html,
                        protectContent: true);

                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[3]);
                     messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[4]);
                     messages = await botClient.SendMessage(message.Chat.Id, "🕹️ На джойстике есть курок (см. фото), которым подтверждаются действия (аналог левой кнопки мыши).\\n\\n\" +\r\n                           \"В игре:\\n\" +\r\n                           \"• Нажмите синюю кнопку ▶️ *PLAY* или 🔄 *RESTART*.\\n\" +\r\n                           \"• Разбивайте кубики под музыку: красным мечом — красные, синим мечом — синие.\U0001f7e5\U0001f7e6",
                        ParseMode.Html,
                        protectContent: true);
                }

                if (message.Text == "/MissionISS")
                {
                    var messages = await botClient.SendMessage(message.Chat.Id, "*Mission ISS 🚀*\n\n" +
                           "🌌 Отправляйтесь на Международную космическую станцию!\n\n" +
                           "Исследуйте станцию изнутри и снаружи, узнайте о жизни космонавтов и выполните увлекательные задания.\n\n" +
                           "✨ *Особенности игры:*\n" +
                           "• Интуитивно понятное управление;\n" +
                           "• Режим планшета для навигации и поиска информации;\n",
                        ParseMode.Html,
                        protectContent: true);

                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[5]);
                }

                if (message.Text == "/SpacePirates")
                {
                    var messages = await botClient.SendMessage(message.Chat.Id, "*Space Pirates ☠️*\n\n" +
                           "👾 Отбивайте атаки роботов в захватывающей космической стрелялке!\n\n" +
                           "🚀 *Как играть:*\n" +
                           "• Стреляйте, используя большие курки на обоих джойстиках (управление одинаковое).\n" +
                           "• Меняйте тип вооружения круглым джойстиком.\n" +
                           "• Чтобы сменить щит на оружие, заведите джойстик за спину.\n\n" +
                           "▶️ *Запуск игры:*\n" +
                           "• В меню выберите режим игры:\n" +
                           "    • SOLO\n" +
                           "    • ARCADE\n" +
                           "    • HARDKOR (по желанию).",
                        ParseMode.Html,
                        protectContent: true);

                    var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[6]);
                }


                if (message.Text == "/Tecla")
                {



                    var messagey = await botClient.SendMessage(message.Chat.Id, "⚡️ *Тесла-шоу* ⚡️" +
                        "\n\n*Приветствие и первый запуск:*" +
                        "\r\n\r\nЗдравствуйте! Меня зовут [Имя ведущего]. Наше шоу называется «Тесла». Как вы думаете, почему? 😉" +
                        "\r\n\r\nПотому что оно посвящено электричеству, а главный экспонат — *катушка Теслы*! Она названа в честь своего изобретателя, гениального сербско-американского ученого Николы Теслы, известного своими открытиями в области электроэнергии и многих других научных областях." +
                        "\r\n\r\nГотовы увидеть катушку в действии? ✨" +
                        "\r\n\r\n*(Интерактивный запуск катушки)*" +
                        "\r\n\r\nУзнали мелодию? 😉 Молодцы! Переходим к следующему эксперименту!" +
                        "\r\n\r\n\r\n*Второй запуск катушки:*" +
                        "\r\n\r\nДля этого эксперимента мне понадобится вот такая лампа. Можете убедиться, что в ней нет батареек.👌" +
                        "\r\n\r\nА как вы думаете, зачем была придумана катушка Теслы? 🤔" +
                        "\r\n\r\nНа самом деле, Никола Тесла создал ее для беспроводной передачи электроэнергии! Он мечтал установить 8 огромных катушек по всему миру, чтобы избавить человечество от проводов. Посмотрим, как это работает? 💡" +
                        "\r\n\r\n*(Запуск катушки)*" +
                        "\r\n\r\nЛампа загорелась? Да! ✨ Здесь работает принцип электромагнитного поля. Запущенная катушка создает вокруг себя поле, и лампа, попадая в него, начинает светиться." +
                        "\r\n\r\nТеперь, вспоминая идею Теслы, мы понимаем, почему масштабировать проект не удалось. 😔 Мощности электромагнитного поля не хватало для обеспечения базовых нужд. К тому же, проект не нашел поддержки у инвесторов. 💰" +
                        "\r\n\r\nПереходим к следующему эксперименту!" +
                        "\r\n\r\n\r\n*Подиум:*" +
                        "\r\n\r\nКак вы думаете, человек может стать проводником электроэнергии? 🤔" +
                        "\r\n\r\nПриглашаем добровольца! (Уточняем у родителей об отсутствии сердечных заболеваний, брекетов, металлических имплантов. Просим убрать металлические предметы из карманов. Родители расписываются в технике безопасности.) ✍️" +
                        "\r\n\r\n*(Запуск подиума. Ребенок произносит «заклинание»)*" +
                        "\r\n\r\nПосвящаем нашего добровольца в рыцари! 🛡️ (Время для фото) 📸" +
                        "\r\n\r\nСекрет подиума — в катушке внутри каркаса. Она такая же, как наша основная, только меньше. Получается цепочка: катушка (источник тока) — человек (проводник) — лампа (приемник). 👏 Спасибо нашему рыцарю!" +
                        "\r\n\r\n\r\n*Генератор Ван де Граафа:*" +
                        "\r\n\r\nПриглашаем девочку! (Уточняем у родителей об отсутствии противопоказаний. Просим убрать металлические предметы. Родители расписываются в ТБ). ✍️" +
                        "\r\n\r\n*(Запуск генератора. Волосы поднимаются вверх!)*" +
                        "\r\n\r\nЗдесь работает статическое электричество. Внутри конструкции — кожаный ремень, который, вращаясь, создает заряд, передающийся человеку. Подобный эксперимент можно провести дома с воздушным шариком и волосами. 🎈 Но если ваши волосы поднимаются в пустыне — это плохой знак! ⚠️ Скоро может ударить молния! ⚡️" +
                        "\r\n\r\n*(Выключаем и заземляем генератор)*" +
                        "\r\n\r\n\r\n*Третий запуск катушки (финал):*" +
                        "\r\n\r\nА теперь — небольшой тест на знание истории космонавтики! 🚀 Кто был первым космонавтом? (Гагарин) ✅ Когда состоялся первый полет? (12 апреля 1961 года) ✅ Какая самая популярная фраза, связанная с космосом? («Поехали!») ✅" +
                        "\r\n\r\nГагарин произнес ее при запуске ракеты. Давайте запустим нашу катушку в последний раз! Все вместе скажем: «Поехали!» 🚀" +
                        "\r\n\r\n*(Обратный отсчет. Запуск катушки)*" +
                        "\r\n\r\nСпасибо за внимание! 👋 Передаем вас экскурсоводам.*"
                        );


                    messagey = await botClient.SendMessage(message.Chat.Id, "Вот ссылка на проведение шоу",
                       ParseMode.Html,
                       protectContent: true,
                       replyParameters: update.Message.Id,
                       replyMarkup: new InlineKeyboardButton("Проведение шоу", "https://drive.google.com/file/d/1LIz3bowA2dc3eEK1K9lcCOO6CRMwoDff/view?usp=sharing"));


                    messagey = await botClient.SendMessage(message.Chat.Id, "Вот техника безопасности на Ван-де-Граф",
                         ParseMode.Html,
                         protectContent: true,
                         replyParameters: update.Message.Id,
                         replyMarkup: new InlineKeyboardButton("Ван-де-граф", ssilkiTB[0]));

                    messagey = await botClient.SendMessage(message.Chat.Id, "Вот техника безопасности на Тесла-подиум",
                        ParseMode.Html,
                        protectContent: true,
                        replyParameters: update.Message.Id,
                        replyMarkup: new InlineKeyboardButton("Тесла-подиум", ssilkiTB[1]));
                }

            }

        }


    }

}


/*
 
    if (message.Text == "/")
        {
            var messages = await botClient.SendMessage(message.Chat.Id, "",
                ParseMode.Html,
                protectContent: true);

            var messagey = await botClient.SendPhoto(message.Chat.Id, ssilkiVR[7]);
        }



*/

