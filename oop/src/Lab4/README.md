Лабораторная 4 – Приложение для взаимодействия и управления файловой системой
=============================================================================

## Проекты в составе реализуемого приложения

* Sources (Class Library) – исходные тексты приложения
* Tests (Unit Tests) – набор тестов для проверки функционала
* FileSystemShell (Console Application) – пример реализации приложения

## Пространства имен реализуемого приложения в проекте Sources

* Filesystem – Взаимодействие с файловой системой
* Filesystem.Model – Модель данных, обрабатываемых приложением
* Filesystem.View – Представление результатов пользователю
* Filesystem.Controller – Контроллер взаимодействия с пользователем
* Logging – Логирование работы компонентов

## Паттерны проектирования, используемые в реализуемом решении

* Mobile-View-Controller (Модель-Представление-Контроллер) –– классы в одноименных пространствах, 
  реализующих компоненты MVC
* Facade (Фасад) –- CommandFacade
* State (Состояние) –– FilesystemContext, FilesystemState, FilesystemDisconnected, FilesystemConnected 
* Компоновщик (Composite) -- TreeItem, TreeDirectory, TreeFile
* Строитель (Builder) -- TreeBuilder
* Factory (Фабрика) –– LogFactory, FileLogFactory, ConsoleLogFactory, 
  Logger, FileLogger, ConsoleLogger

## Подготовка к работе

1. Открыть терминал
2. Перейти в директорию /tmp и создать каталог fss
   ```
   $ mkdir -p /tmp/fss 
   $ cd /tmp/fss && pwd
   ``` 
3. Создать в директории /tmp/fss текстовый файл test.txt
   ```
   $ cat >test.txt
   $ cat /tmp/fss/test.txt
   ```
   
## История изменений

### 03.12.2023
* Проведен рефакторинг кода для исключения ошибок на соответствие следования правилам.
* Добавлен тест-кейс парсера команд.

### 02.12.2023
* Добавлено визуальное разделение последовательности выполняемых команд в Display.
* Добавлены проверка и обработка исключений в Shell, CommandFacade, Display.
* Расширены проверки корректности вводимых пользователем команд в пространстве Model. 
* Реализованы вызов всех команд в классе FilesystemContext с передачей их на обработку в класс FilesystemConnected.
* Реализованы команда GotoTree в классе FilesystemConnected.
* Реализованы команды ShowFile, MoveFile, CopyFile, DeleteFile, RenameFile в классе FilesystemConnected.
* Реализована команда ListTree в классе FilesystemConnected.

### 01.12.2023 21:25
* Реализован паттерн Состояние для файловой системы в пространстве Filesystem.Model.
* Реализована команда Connect в классах FilesystemContext, FilesystemDisconnected.
* Реализована команда Disconnect в классах FilesystemContext, FilesystemConnected.

### 01.12.2023 19:33
* Реализован класса Shell в пространстве Filesystem.Controller.
* Реализован класса CommandList в пространстве Filesystem.Model.
* Реализован класса Display в пространстве Filesystem.View.
* Протестирован ввод команд, распределение по обработчикам, отображение результатов.

### 30.11.2023
* Начаты работы над реализацией приложения.
* Переработаны классы Logging – в LogFactory реализованы  методы Create и Get,
  добавлены ConsoleLogFactory и ConsoleLogger.
* Выбран прототип MVC для реализации приложения.
* Реализован прототип консольного приложения FileSystemShell.
