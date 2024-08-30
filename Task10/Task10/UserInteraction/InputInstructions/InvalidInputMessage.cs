namespace Task10;

public static class InvalidInputMessage
{
    public const string DescriptionInvalidInput = "Описание задачи должно содержать только буквы латинского или кириллического алфавита и цифры. " +
                                                  "Выберите другое описание для задачи.";

    public const string DateTimeInvalidInput = "Некорректный формат даты и времени. Введите дату и время в формате ДД.ММ.ГГ ЧЧ.ММ.СС +ЧЧ:ММ";
    public const string PriorityInvalidInput = "Некорректный приоритет задачи. Введите одно из указанных значений: высокий, средний или низкий";
}