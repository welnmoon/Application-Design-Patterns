using System;

class HiringProcess
{
    public void StartHiringProcess()
    {
        Console.WriteLine("Процесс найма начат.");

        // Этап 1: Проверка заявки
        bool requestApproved = CheckJobRequest();
        if (!requestApproved)
        {
            Console.WriteLine("Заявка не утверждена. Завершение процесса.");
            return;
        }

        // Этап 2: Публикация вакансии
        PostVacancy();

        // Этап 3: Прием анкет кандидатов
        bool candidateFound = ReviewApplications();
        if (!candidateFound)
        {
            Console.WriteLine("Нет подходящих кандидатов. Завершение процесса.");
            return;
        }

        // Этап 4: Проведение собеседований
        bool interviewPassed = ConductInterviews();
        if (!interviewPassed)
        {
            Console.WriteLine("Собеседования не пройдены. Завершение процесса.");
            return;
        }

        // Этап 5: Предложение оффера
        bool offerAccepted = MakeOffer();
        if (!offerAccepted)
        {
            Console.WriteLine("Оффер не принят. Завершение процесса.");
            return;
        }

        // Этап 6: Настройка рабочего места
        FinalizeHiring();

        Console.WriteLine("Процесс найма завершен успешно.");
    }

    private bool CheckJobRequest()
    {
        Console.WriteLine("Проверка заявки...");
        return true; // Заявка утверждена
    }

    private void PostVacancy()
    {
        Console.WriteLine("Публикация вакансии...");
    }

    private bool ReviewApplications()
    {
        Console.WriteLine("Проверка анкет кандидатов...");
        return true; // Найден подходящий кандидат
    }

    private bool ConductInterviews()
    {
        Console.WriteLine("Проведение собеседований...");
        return true; // Собеседования пройдены
    }

    private bool MakeOffer()
    {
        Console.WriteLine("Предложение оффера кандидату...");
        return true; // Оффер принят
    }

    private void FinalizeHiring()
    {
        Console.WriteLine("Настройка рабочего места и добавление сотрудника в базу данных...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        HiringProcess hiringProcess = new HiringProcess();
        hiringProcess.StartHiringProcess();
    }
}
