namespace Task9.UserInput
{
    public static class InputInstructions
    {
        public const string StartRules = @"
            В начале доступны две команды:
            - get
            - start

            После ввода 'get' вам доступны команды:
            - items
            - description

            После ввода 'get items/description' введите имя персонажа из начального списка.
            После команды 'start' вы должны ввести имя персонажа из начального списка.
            Команда 'start' может быть вызвана только один раз."
        ;

        public const string AfterStartRules = @"
            После ввода 'start (персонаж)', вам доступны еще две команды:
            - show info
            - add ability

            После ввода 'add ability' вам надо ввести:
            - Наименование новой способности
            - Описание
            - Стоимость маны
            - Одну из стихий: Earth, Fire, Water, Air"
        ;
    }
}
