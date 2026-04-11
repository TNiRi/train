using System;
using System.Collections.Generic;

public static class WorldBuilder
{
    public static GameState CreateGame()
    {
        // ========== ЛОКАЦИИ БУНКЕРА ==========
        Location entry = new Location("Вход в бункер", "Ты у тяжёлой двери. Темно. Надпись: 'storage'.");
        
        Location darkCorridor = new Location("Тёмный мигающий коридор", "Свет мигает. На стене выцарапан код: 4815. В углу деревянный ящик 'crate'.");
        
        Location storage = new Location("Склад", "Старые ящики, инструменты. В углу стоит ржавый сейф 'safe'.");
        
        Location generatorRoom = new Location("Генераторная", "Гулкое помещение. Генератор молчит.");
        
        Location exitHall = new Location("Выходной холл", "Дверь наружу заварена. Тихо.");

        // ========== СЛЕДУЮЩАЯ ЛОКАЦИЯ ==========
        Location nextWorld = new Location("Новый мир", "Ты перенёсся в неизвестное место. Здесь пока ничего нет.");

        // ========== ОБЪЕКТЫ ==========
        Safe safe = new Safe("safe", "Сейф", "Ржавый сейф с цифровым замком", "4815", "Лом");
        storage.AddObject(safe);

        LockedCrate crate = new LockedCrate("crate", "Деревянный ящик", "Крепкий ящик, сбитый железными полосами", "Лом", "Ключ от генератора");
        darkCorridor.AddObject(crate);

        Door door = new Door("door", "Дверь в генераторную", "Тяжёлая дверь с замком", "Ключ от генератора", generatorRoom);
        storage.AddObject(door);

        Generator generator = new Generator("generator", "Генератор", "Большая машина. Есть кнопка.");
        generatorRoom.AddObject(generator);

        Trap trap = new Trap("trap", "Растяжка", "Проволока на полу", 20, true);
        storage.AddObject(trap);

        // ========== NPC ==========
        Npc ghost = new Npc("ghost", "Призрак инженера", "Прозрачная фигура в грязной спецовке.");
        ghost.AddDialogue("hello", "Я Сергей... Код от сейфа — 4815.");
        ghost.AddDialogue("code", "4815. Не потеряй.");
        ghost.AddDialogue("crowbar", "Лом в сейфе. Им можно взломать ящик в коридоре.");
        ghost.AddDialogue("key", "Ключ в ящике. Откроешь дверь в генераторную.");
        ghost.AddDialogue("generator", "Вставь ключ и нажми кнопку.");
        ghost.AddDialogue("safe", "Сейф на складе. Код 4815.");
        ghost.AddDialogue("crate", "Ящик в коридоре. Взломай его ломом.");
        ghost.AddDialogue("door", "Дверь в генераторную. Открывается ключом.");
        storage.AddObject(ghost);

        // ========== ПЕРЕХОДЫ (кодовые слова — на английском) ==========
        entry.AddExit("storage", storage);
        entry.AddExit("corridor", darkCorridor);
        
        darkCorridor.AddExit("entry", entry);
        darkCorridor.AddExit("storage", storage);
        
        storage.AddExit("corridor", darkCorridor);
        storage.AddExit("generator", generatorRoom);
        
        generatorRoom.AddExit("storage", storage);
        generatorRoom.AddExit("exit", exitHall);
        
        exitHall.AddExit("entry", entry);

        // ========== ТЁМНЫЙ КОРИДОР (урон без света) ==========
        ICondition noLight = new NotCondition(new HasItemCondition("Фонарик"));
        var darkEffects = new List<IEffect> { new DamageEffect(5), new LogEffect("Мигающий свет режет глаза... Теряешь здоровье.") };
        OnTurnEvent darkEvent = new OnTurnEvent(noLight, darkEffects, false);
        darkCorridor.AddEvent(darkEvent);

        // ========== КВЕСТ ==========
        ICondition generatorNotOn = new NotCondition(new FlagCondition("GeneratorOn", true));
        ICondition fuseUsed = new FlagCondition("FuseUsed", true);
        ICondition questCondition = new AndCondition(generatorNotOn, fuseUsed);

        var questReward = new List<IEffect>
        {
            new LogEffect("Генератор ожил! Лампы перестали мигать."),
            new SetFlagEffect("GeneratorOn", true),
            new AddExitEffect("Выходной холл", "portal", nextWorld),
            new LogEffect("На стене загорелось слово: PORTAL. Теперь ты можешь уйти в другой мир.")
        };

        Quest generatorQuest = new Quest("Запустить генератор", "Найди способ добраться до генератора и включить его", questCondition, questReward);

        // ========== СОСТОЯНИЕ ИГРЫ ==========
        GameState state = new GameState(entry);
        state.RegisterLocation(entry);
        state.RegisterLocation(darkCorridor);
        state.RegisterLocation(storage);
        state.RegisterLocation(generatorRoom);
        state.RegisterLocation(exitHall);
        state.RegisterLocation(nextWorld);
        state.AddQuest(generatorQuest);

        state.AddEventLog("Ты в бункере. В тёмном коридоре что-то написано на стене.");
        state.AddEventLog("Призрак на складе может помочь. Попробуй: ask hello");

        return state;
    }
}