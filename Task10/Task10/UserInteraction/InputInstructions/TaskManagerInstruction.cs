﻿namespace Task10;

public static class TaskManagerInstructions
{
    public const string AddTaskInstruction = 
        "Чтобы добавить задачу, введите команду в следующем формате:\n" +
        "add <Название задачи> \"<Описание задачи>\" <Дата> <Время> <Часовой пояс> <Приоритет>.\n" +
        "Пример: add МояЗадача \"Описание\" 20.09.23 14.00.00 +0300 High.\n" +
        "Описание задачи — опционально и должно быть в кавычках, приоритет по умолчанию Medium.";
    
    public const string DeleteTaskInstruction = 
        "Чтобы удалить задачу, введите команду в следующем формате:\n" +
        "delete <ID задачи>.\n" +
        "Пример: delete 1.\n" +
        "ID задачи можно найти в списке задач.";
    
    public const string UpdateTaskInstruction = 
        "Чтобы обновить задачу, введите команду в следующем формате:\n" +
        "update <ID задачи> <Новое название> \"<Новое описание>\" <Дата> <Время> <Часовой пояс> <Приоритет>.\n" +
        "Пример: update 1 ОбновленнаяЗадача \"Новое описание\" 21.09.23 10.30.00 +0300 Low.\n" +
        "Если описание задачи не требуется, его можно пропустить.";
    
    public const string SortTaskInstruction = 
        "Чтобы отсортировать задачи, введите команду в следующем формате:\n" +
        "sort <Параметр> <Порядок>.\n" +
        "Доступные параметры для сортировки: id, name, priority, date.\n" +
        "Порядок сортировки: asc (по возрастанию) или desc (по убыванию).\n" +
        "Пример: sort name asc (сортировка по имени в возрастающем порядке) или sort priority desc (по приоритету в убывающем порядке).";
    
    public const string GeneralInstruction = 
        "Добро пожаловать в TaskManager!\n" +
        "Вы можете управлять своими задачами с помощью следующих команд:\n" +
        "1. Добавить задачу — команда add.\n" +
        "2. Удалить задачу — команда delete.\n" +
        "3. Обновить задачу — команда update.\n" +
        "4. Сортировать задачи — команда sort.\n" +
        "Для завершения работы программы введите команду exit.";
}