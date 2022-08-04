# Patron.WebWriter - система, позволяющая виртуализировать раннюю реализацию бэкенда за счёт возврата данных о файлах сервера.

## Возможности:

1) Запрашивание наличия файла по его названию.
2) Получение информации о файле.
3) Возврат ошибок в результате возможных нежелательных результатов обработки.
4) Оптимизацию скорости обработки за счёт проверки на единовременную обработку несколькими клиентами одного и того же файла.

## Полезные знания:
+ [Исходный код приложения](https://github.com/QviNSteN/Patron.WebWriter)
+ [ТЗ](https://github.com/QviNSteN/Patron.WebWriter/blob/master/wiki/tz.md#%D1%82%D0%B5%D1%85%D0%BD%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%BE%D0%B5-%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5)
+ [Описание архитектуры](https://github.com/QviNSteN/Patron.WebWriter/blob/master/wiki/architecture.md#%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%86%D0%B8%D1%8F-%D0%BE%D0%B1-%D0%B0%D1%80%D1%85%D0%B8%D1%82%D0%B5%D0%BA%D1%82%D1%83%D1%80%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%B8-%D0%BF%D0%BE%D0%B4%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%BD%D1%8B%D1%85-%D0%B1%D0%B8%D0%B1%D0%BB%D0%B8%D0%BE%D1%82%D0%B5%D0%BA)
+ [Немного о нагрузочном тестировании](https://github.com/QviNSteN/Patron.WebWriter/blob/master/wiki/hard-testing.md#%D0%BC%D1%8B%D1%81%D0%BB%D0%B8-%D0%BF%D0%BE-%D0%BF%D0%BE%D0%B2%D0%BE%D0%B4%D1%83-%D0%BD%D0%B0%D0%B3%D1%80%D1%83%D0%B7%D0%BE%D1%87%D0%BD%D0%BE%D0%B3%D0%BE-%D1%82%D0%B5%D1%81%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
+ [Метрики](https://github.com/QviNSteN/Patron.WebWriter/blob/master/wiki/metrics.md#%D0%BC%D0%B5%D1%82%D1%80%D0%B8%D0%BA%D0%B8-%D0%B8-%D0%B4%D0%BE%D0%BF-%D0%BD%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B8)
+ В разработке...

## Развёртка

В данный момент всё настроено на сбор приложения с помощью docker-compose.

+ git pull для обновления версии.
+ run.sh позволяет запустить цикл перезапуска и сборки новой версии.
