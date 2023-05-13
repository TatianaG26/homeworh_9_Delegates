using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworh_9_Delegates
{
    internal class Задание_3
    {
        /* Создайте класс «Кредитная карточка». 
        Класс должен содержать:
        ■ Номер карты;
        ■ ФИО владельца;
        ■ Срок действия карты;
        ■ PIN;
        ■ Кредитный лимит;
        ■ Сумма денег.
        Создайте необходимый набор методов класса. 
        
        Реализуйте события для следующих ситуаций:
        ■ Пополнение счёта;
        ■ Расход денег со счёта;
        ■ Старт использования кредитных денег;
        ■ Достижение заданной суммы денег;
        ■ Смена PIN.*/
        class CreditCard
        {
            string CardNumber { get; set; } // Номер карты
            string CardOwnerName { get; set; } // ФИО владельца
            DateTime ExpirationDate { get; set; } // Срок действия карты
            int Pin { get; set; } // PIN
            decimal CreditLimit { get; set; } // Кредитный лимит
            decimal Balance { get; set; } // Сумма денег

            public CreditCard(string cardNumber, string cardOwnerName, DateTime expirationDate, int pin, decimal creditLimit, decimal balance)
            {
                CardNumber = cardNumber;
                CardOwnerName = cardOwnerName;
                ExpirationDate = expirationDate;
                Pin = pin;
                CreditLimit = creditLimit;
                Balance = balance;
            }            
            public void TopUp(decimal amount) // Метод для пополнения счета
            {
                Balance += amount;

                // Генерируем событие TopUpEvent
                TopUpEvent?.Invoke(this, amount);
            }
            public void Spend(decimal amount) // Метод для расхода денег со счета
            {
                // Проверяем, достаточно ли денег на счете
                if (Balance + CreditLimit >= amount)
                {
                    Balance -= amount;

                    // Генерируем событие SpendEvent
                    SpendEvent?.Invoke(this, amount);
                }
            }
            public void StartCredit() // Метод для начала использования кредитных денег
            {   
                // Генерируем событие StartUsingCreditEvent
                StartCreditEvent?.Invoke(this, EventArgs.Empty);
            }
            public void ChangePin(int newPin) // Метод для смены PIN-кода
            {
                Pin = newPin;

                // Генерируем событие ChangePinEvent
                ChangePinEvent?.Invoke(this, newPin);
            }

            // Определяем события класса
            public event EventHandler<decimal> TopUpEvent; // Событие для пополнения счета
            public event EventHandler<decimal> SpendEvent; // Событие для расхода денег со счета
            public event EventHandler<EventArgs> StartCreditEvent; // Событие для начала использования кредитных денег
            public event EventHandler<int> ChangePinEvent; // Событие для смены PIN-кода
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Создаем экземпляр класса CreditCard
                CreditCard creditCard = new CreditCard("1234 5678 9012 3456", "Иванов Иван Иванович",
                    new DateTime(2025, 12, 31), 1234, 1000, 5000);

                // Подписываемся на события класса CreditCard
                creditCard.TopUpEvent += CreditCard_TopUpEvent;
                creditCard.SpendEvent += CreditCard_SpendEvent;
                creditCard.StartCreditEvent += CreditCard_StartUsingCreditEvent;
                creditCard.ChangePinEvent += CreditCard_ChangePinEvent;

                // Тестируем методы класса CreditCard
                creditCard.TopUp(3000);
                creditCard.Spend(2000);
                creditCard.StartCredit();
                creditCard.ChangePin(5678);
            }

            // Обработчики событий класса CreditCard
            private static void CreditCard_TopUpEvent(object sender, decimal amount)
            {
                Console.WriteLine($"Счет пополнен на {amount}");
            }

            private static void CreditCard_SpendEvent(object sender, decimal amount)
            {
                Console.WriteLine($"Со счета списано {amount}");
            }

            private static void CreditCard_StartUsingCreditEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Кредитные деньги начали использоваться");
            }

            private static void CreditCard_ChangePinEvent(object sender, int newPin)
            {
                Console.WriteLine($"Новый PIN-код: {newPin}");
            }
        }
    }

}

