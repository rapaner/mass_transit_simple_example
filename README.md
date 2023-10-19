# Пример работы MassTransit

## Подготовка к запуску
Для запуска необходим Docker Desktop и запущенный контейнер с образом rabbitmq

## Проекты
MassTransitExample является производителем данных.\
В [OrdersController](MassTransitExample/Controllers/OrdersController.cs) три метода:
- CreateOrder - публикует событие методом Publish, которое обрабатывается в [OrderCreatedConsumer](Consumer/OrderCreatedConsumer.cs)
- CancelOrder - команда с помощью метода Send, которая обрабатывается в [CancelOrderConsumer](Consumer/CancelOrderConsumer.cs)
- GetOrder - запрос с помощью RequestClient, который обрабатывается в [GetOrderRequestConsumer](Consumer/GetOrderRequestConsumer.cs)