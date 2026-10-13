SocialHub (ASP.NET Core MVC)

SocialHub — це вебзастосунок стрічки новин та обговорень, створений за допомогою технології ASP.NET Core MVC та Entity Framework Core. Проєкт містить систему постів, коментарів та користувачів із підтримкою повноцінної роботи з базою даних.

🛠 Технології в проєкті

Backend: C#, ASP.NET Core MVC, LINQ

ORM: Entity Framework Core (Code First з міграціями)

Frontend: Bootstrap 5, HTML5, CSS3, Razor Views

Database: Microsoft SQL Server (LocalDB / SQL Server)

📂 Структура проєкту

Context/ — налаштування контексту бази даних (AppDbContext.cs).

Controllers/ — логіка обробки запитів (AccountController, PostController, CommentController).

Migrations/ — історія міграцій структури бази даних.

Models/ — сутності даних (Post, Comment, User, ErrorViewModel).

Views/ — інтерфейс користувача (Razor-шаблони для Account, Post, Comment та Shared).

appsettings.json — конфігурація застосунку та рядки підключення до бази даних.

Program.cs — точка входу та налаштування сервісів (DI) конфігурації.

🚀 Інструкція із запуску (Quick Start)

Щоб успішно запустити та протестувати проєкт на своєму комп'ютері, виконайте такі кроки:

1. Клонування або відкриття проєкту

Відкрийте завантажений проєкт у середовищі розробки Visual Studio (або відкрийте папку проєкту через VS Code / термінал).

2. Налаштування рядка підключення до бази даних

Переконайтеся, що у файлі appsettings.json правильно прописаний рядок підключення (ConnectionStrings:DefaultConnection) до вашого екземпляра SQL Server або LocalDB (наприклад, Server=(localdb)\\mssqllocaldb;Database=SocialHubDb;Trusted_Connection=True;MultipleActiveResultSets=true).

3. Застосування міграцій бази даних

Щоб створити базу даних та таблиці автоматично на основі наявних міграцій, відкрийте Package Manager Console у Visual Studio (Tools -> NuGet Package Manager -> Package Manager Console) та виконайте команду:

Update-Database


(Це створить базу даних із необхідними таблицями Users, Posts та Comments).

4. Автоматичне заповнення тестовими даними (Seeder)

Під час першого запуску застосунку спрацьовує ініціалізатор бази даних (DbInitializer), який автоматично наповнює порожню базу тестовими користувачами, 10 цікавими постами та коментарями для повноцінної роботи стрічки.

5. Запуск застосунку

Натисніть зелену кнопку Start (F5) у Visual Studio.

Проєкт відкриється у браузері за замовчуванням (маршрут за замовчуванням налаштований на сторінку Account/Login або головну сторінку постів).
