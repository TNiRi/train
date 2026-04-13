using System;
using System.Collections.Generic;

public static class WorldBuilder
{
    public static GameState CreateGame()
    {
        // ========== ЛОКАЦИИ БУНКЕРА ==========
        Location entry = new Location("Вход в бункер", "Ты у тяжёлой двери. Темно. Надпись: 'storage'.");
        
        Location darkCorridor = new Location("Тёмный мигающий коридор", "Свет мигает. На стене выцарапан код: 4815. В углу деревянный ящик 'crate'.");
        
        Location storage = new Location("Склад", "Старые ящики, инструменты. В углу стоит ржавый сейф 'safe'. Видна дверь 'door'.");
        
        Location generatorRoom = new Location("Генераторная", "Гулкое помещение. Генератор молчит.");
        
        Location exitHall = new Location("Выходной холл", "Дверь наружу заварена. Тихо.");

        // ========== СЛЕДУЮЩАЯ ЛОКАЦИЯ ==========
        Location nextWorld = new Location("Новый мир", "Ты перенёсся в неизвестное место. Здесь пока ничего нет.");

        // ========== ОБЪЕКТЫ ==========
        // Сейф (даёт лом)
        Safe safe = new Safe("safe", "Сейф", "Ржавый сейф с цифровым замком", "4815", "Лом");
        storage.AddObject(safe);

        // Ящик (даёт ключ от двери, взламывается ломом)
        LockedCrate crate = new LockedCrate("crate", "Деревянный ящик", "Крепкий ящик, сбитый железными полосами", "Лом", "Ключ от двери");
        darkCorridor.AddObject(crate);

        // Дверь (открывается ключом от двери)
        Door door = new Door("door", "Дверь в генераторную", "Тяжёлая дверь с замком", "Ключ от двери", generatorRoom);
        storage.AddObject(door);

        // Генератор (запускается предохранителем)
        Generator generator = new Generator("generator", "Генератор", "Большая машина. Есть кнопка.", "Предохранитель");
        generatorRoom.AddObject(generator);

        // Ловушка
        Trap trap = new Trap("trap", "Растяжка", "Проволока на полу", 20, true);
        storage.AddObject(trap);

        // Сундук с предметами (появляется после разговора с призраком)
        var chestItems = new List<string> { "Предохранитель", "Фонарик" };
        Chest chest = new Chest("treasure", "Сундук", "Старый ржавый сундук", chestItems);
        storage.AddObject(chest);

        // ========== NPC ==========
        Npc ghost = new Npc("ghost", "Призрак инженера", "Прозрачная фигура в грязной спецовке.");
        ghost.AddDialogue("hello", "Я Сергей... Код от сейфа — 4815.");
        ghost.AddDialogue("code", "4815. Не потеряй.");
        ghost.AddDialogue("crowbar", "Лом в сейфе. Им можно взломать ящик в коридоре.");
        ghost.AddDialogue("key", "Ключ в ящике. Откроешь дверь в генераторную.");
        ghost.AddDialogue("generator", "Чтобы запустить генератор, нужен предохранитель. Он в сундуке.");
        ghost.AddDialogue("safe", "Сейф на складе. Код 4815.");
        ghost.AddDialogue("crate", "Ящик в коридоре. Взломай его ломом.");
        ghost.AddDialogue("door", "Дверь в генераторную. Открывается ключом.");
        ghost.AddDialogue("chest", "Сундук на складе. Откроется, когда поговоришь со мной.");
        storage.AddObject(ghost);

        // ========== ПЕРЕХОДЫ (БЕЗ ПРЯМОГО ПЕРЕХОДА В ГЕНЕРАТОРНУЮ) ==========
        entry.AddExit("storage", storage);
        entry.AddExit("corridor", darkCorridor);
        
        darkCorridor.AddExit("entry", entry);
        darkCorridor.AddExit("storage", storage);
        
        storage.AddExit("corridor", darkCorridor);
        // НЕТ перехода "generator"! Он добавится после открытия двери
        
        generatorRoom.AddExit("storage", storage);
        generatorRoom.AddExit("exit", exitHall);
        
        exitHall.AddExit("entry", entry);

        // ========== ТЁМНЫЙ КОРИДОР (урон без света) ==========
        ICondition noLight = new NotCondition(new HasItemCondition("Фонарик"));
        var darkEffects = new List<IEffect> { new DamageEffect(5), new LogEffect("Мигающий свет режет глаза... Теряешь здоровье.") };
        OnTurnEvent darkEvent = new OnTurnEvent(noLight, darkEffects, false);
        darkCorridor.AddEvent(darkEvent);

        // ========== КВЕСТ 1: ЗАПУСТИТЬ ГЕНЕРАТОР ==========
        ICondition generatorNotOn = new NotCondition(new FlagCondition("GeneratorOn", true));
        ICondition fuseUsed = new FlagCondition("FuseUsed", true);
        ICondition questCondition = new AndCondition(generatorNotOn, fuseUsed);

        var questReward = new List<IEffect>
        {
            new LogEffect("Генератор ожил! Лампы перестали мигать."),
            new SetFlagEffect("GeneratorOn", true)
        };

        Quest generatorQuest = new Quest("Запустить генератор", "Найди способ добраться до генератора и включить его", questCondition, questReward);

        // ========== КВЕСТ 2: ПОКИНУТЬ БУНКЕР (ВТОРОЙ КВЕСТ ПО ТЗ) ==========
        ICondition generatorOn = new FlagCondition("GeneratorOn", true);
        ICondition notExited = new NotCondition(new FlagCondition("Exited", true));
        ICondition secondQuestCondition = new AndCondition(generatorOn, notExited);

        var secondQuestReward = new List<IEffect>
        {
            new LogEffect("Ты нашёл путь наружу!"),
            new SetFlagEffect("Exited", true),
            new AddExitEffect("Выходной холл", "portal", nextWorld),
            new LogEffect("На стене загорелось слово: PORTAL. Теперь ты можешь уйти в другой мир.")
        };

        Quest secondQuest = new Quest("Покинуть бункер", "Найди выход из бункера", secondQuestCondition, secondQuestReward);

        // ========== СОСТОЯНИЕ ИГРЫ ==========
        GameState state = new GameState(entry);
        state.RegisterLocation(entry);
        state.RegisterLocation(darkCorridor);
        state.RegisterLocation(storage);
        state.RegisterLocation(generatorRoom);
        state.RegisterLocation(exitHall);
        state.RegisterLocation(nextWorld);
        state.AddQuest(generatorQuest);
        state.AddQuest(secondQuest);

        state.AddEventLog("Ты в бункере. Призрак на складе может помочь. Попробуй: ask hello");

        return state;
    }
}