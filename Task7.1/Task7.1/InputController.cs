namespace Task7._1
{
    public class InputController
    {
        public void HandlerInput() 
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введена пустая строка");
                    continue;
                }
                var words = input.Split(' ')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();                
            }
        }
    }
}

