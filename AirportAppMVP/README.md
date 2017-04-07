# Вариант реализации приложения на основе паттерна Model-View-Presenter

![pic1](https://github.com/ar1st0crat/OODesignCaseStudies/blob/master/Images/MVP_diagram.png)

Главное изменение по сравнению с MVC заключается в том, что модель с представлением коммуницируют только через контроллер (который в данном паттерне называется презентером).

MVP workflow:

1) Презентер подписывается на события представления. При каком-либо действии пользователя инициируется некоторое событие (```FlightsQueried``` и ```FlightsByDepartureCityQueried```) и, соответственно, вызывается метод презентера.

2) Презентер вызывает соответствующий метод модели, после чего...

3), 4) ...сам же занимается обновлением представления: ```_model.Load(); ShowFlights();```.

![pic2](https://github.com/ar1st0crat/OODesignCaseStudies/blob/master/Images/AirportAppMVP.png)