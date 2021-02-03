# Вариант реализации приложения на основе реактивных расширений

Вкратце, если говорить об Rx в .Net:

```
RxNet = Observables + LINQ + Schedulers
```

Observables - для представления *асинхронных потоков данных/событий*

LINQ - для запросов к *асинхронным потокам данных/событий* (Rx операторы)

Schedulers - для управления конкурентностью в *асинхронных потоках данных/событий*

---

Отличия Rx от PubSub / EventAggregator / Mediator:

- декларативность и push-based
- больший акцент на асинхронности
- можно комбинировать цепочки из встроенных операторов (filter, map, throttle, debounce, etc.)
- ближе к паттерну Observer, чем к паттерну Mediator

Reactive manifesto:

- Responsive: быстрый отклик на события
- Resilient: устойчивость к ошибкам
- Elastic: независимость от вычислительных ресурсов
- Message Driven: в основе лежат асинхронные события/сообщения


Паттерн "Наблюдатель" предполагает наличие наблюдаемого объекта/коллекции и наблюдателя (это может быть что угодно, что реагирует на сообщения/события от наблюдаемого объекта).

```
<observable>.Subscribe(<observer>)
```

Простейший пример на Rx .NET:

```C#

class PageChanged 
{
    public int PageNo { get; set; }
}

// ...

ISubject<PageChanged> nextPage = new Subject<PageChanged>();

nextPage.Subscribe(UpdatePageView);
nextPage.Subscribe(CalculatePageStats);
nextPage.Subscribe(p => MessageBox.Show(p.PageNo));


// В общем случае три функции указываются:
// nextPage.Subscribe(OnNext, OnError, OnCompleted);

// Пример оператора с observable:
// nextPage.Where(p => p.PageNo == 0).Subscribe(ZeroPage);

```

Сама идея реактивного программирования достаточно проста, но изучение конкретных реализаций/фреймворков может занять время.
В данном проекте использованы ReactiveUI.Wpf (Rx + MVVM + Wpf) и DynamicData:

![pic1](https://github.com/ar1st0crat/OODesignCaseStudies/blob/master/Images/rx_diagram.png)


Также в проекте показана часто применяемая сервисно-репозиторная архитектура:

```C#

    public class FlightService
    {
        public readonly SourceList<Flight> _flightSource = new SourceList<Flight>();

        /// <summary>
        /// Получаем из репозитория рейсы и возвращаем observable для них
        /// </summary>
        public IObservable<IChangeSet<Flight>> Connect()
        {
            _flightSource.AddRange(GetFlights());

            return _flightSource.Connect();
        }

        public IEnumerable<Flight> GetFlights()
        {
            return MockRepository.Flights;
        }
        
        // ...
    }

```
