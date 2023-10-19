# ������ ������ MassTransit

## ���������� � �������
��� ������� ��������� Docker Desktop � ���������� ��������� � ������� rabbitmq

## �������
MassTransitExample �������� �������������� ������.\
� [OrdersController](MassTransitExample/Controllers/OrdersController.cs) ��� ������:
- CreateOrder - ��������� ������� ������� Publish, ������� �������������� � [OrderCreatedConsumer](Consumer/OrderCreatedConsumer.cs)
- CancelOrder - ������� � ������� ������ Send, ������� �������������� � [CancelOrderConsumer](Consumer/CancelOrderConsumer.cs)
- GetOrder - ������ � ������� RequestClient, ������� �������������� � [GetOrderRequestConsumer](Consumer/GetOrderRequestConsumer.cs)