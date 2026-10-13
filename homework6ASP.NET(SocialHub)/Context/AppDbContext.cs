using homework6ASP.NET_SocialHub_.Models;
using lesson6_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson6_ASP.NET.Context
{
    public class AppDbContext : DbContext
    {
        //==========================AI SEEDER==========================
        public static void Seed(AppDbContext context)
        {
            // Перевіряємо, чи є вже пости в базі, щоб не дублювати дані при кожному запуску
            if (context.Posts.Any())
            {
                return; // База вже заповнена
            }

            // 1. Створюємо тестових користувачів
            var users = new List<User>
            {
                new User { Username = "admin", Password = "admin"},
                new User { Username = "adrij", Password = "123" },
                new User { Username = "MaxDev", Password = "123" },
                new User { Username = "Olya_K", Password = "123" },
                new User { Username = "CodeMaster", Password = "123" },
                new User { Username = "Engineer22", Password = "123" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // 2. Створюємо 10 постів із коментарями
            var posts = new List<Post>
            {
                new Post
                {
                    Author = "MaxDev",
                    Title = "Чому варто спробувати Linux у 2026 році?",
                    Text = "Багато хто досі думає, що Linux — це тільки для бородатих системних адміністраторів, які пишуть код у чорному терміналі. Але сучасні дистрибутиви та кастомні середовища виглядають неймовірно красиво й працюють швидше за Windows.",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "adrij", Text = "Повністю згоден! Сам налаштував собі кастомний віконний менеджер — тепер не можу дивитися на звичайні вікна.", CreatedAt = DateTime.Now.AddDays(-5).AddHours(1) },
                        new Comment { Author = "Olya_K", Text = "Головне — не зламати систему під час чергового оновлення пакета драйверів відеокарти 😅", CreatedAt = DateTime.Now.AddDays(-5).AddHours(2) }
                    }
                },
                new Post
                {
                    Author = "CodeMaster",
                    Title = "Як не втратити мотивацію під час вивчення програмування?",
                    Text = "Коли тільки починаєш вивчати C# чи вебдевелопмент, очі горять. Але через кілька місяців стикаєшся з купою помилок, незрозумілим синтаксисом EF Core та міграціями бази даних. Розкажіть, як ви боретеся з цим?",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "adrij", Text = "Мені допомагає перемикання на створення іншого маленького пет-проєкту або гра в улюблену стратегію.", CreatedAt = DateTime.Now.AddDays(-4).AddHours(1) },
                        new Comment { Author = "Engineer22", Text = "Ого, біль на мільйон! Особливо коли падає база через циклічні зв'язки.", CreatedAt = DateTime.Now.AddDays(-4).AddHours(3) }
                    }
                },
                new Post
                {
                    Author = "Engineer22",
                    Title = "Factorio чи Satisfactory: що краще для вечора п'ятниці?",
                    Text = "Обидві гри змушують будувати заводи, автоматизувати процеси та оптимізувати логістику. Але в одній ви дивитесь зверху, а в іншій — бігаєте від першої особи. Який ваш вибір?",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "MaxDev", Text = "Тільки Factorio, тільки хардкор і автоматизація конвеєрів!", CreatedAt = DateTime.Now.AddDays(-3).AddHours(1) },
                        new Comment { Author = "Olya_K", Text = "У Satisfactory будувати заводи в 3D — це справжній виклик для архітектора.", CreatedAt = DateTime.Now.AddDays(-3).AddHours(2) }
                    }
                },
                new Post
                {
                    Author = "adrij",
                    Title = "REST API на Node.js чи ASP.NET Core MVC?",
                    Text = "Зараз стільки суперечок про те, що краще використовувати для бекенду. Хтось топить за швидкий та гнучкий Node.js з Express, а хтось обожнює потужний стек від Microsoft. А що ви обираєте?",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "CodeMaster", Text = "C# та .NET Core — це любов назавжди, особливо з нормальним ORM.", CreatedAt = DateTime.Now.AddDays(-2).AddHours(1) },
                        new Comment { Author = "MaxDev", Text = "Node.js швидше розгортається, якщо треба накинути швидкий бд-сервер на Prisma та PostgreSQL.", CreatedAt = DateTime.Now.AddDays(-2).AddHours(2) }
                    }
                },
                new Post
                {
                    Author = "Olya_K",
                    Title = "Двомоніторна система — розкіш чи необхідність?",
                    Text = "Нещодавно перейшов на сетап із двома моніторами (один швидкий 2K для основного софту, другий додатковий). Тепер не уявляю, як раніше писав код і одночасно стежив за документацією на одному екрані.",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "Engineer22", Text = "Два монітори — це мінімум! На одному код, на другому логи або термінал.", CreatedAt = DateTime.Now.AddDays(-2).AddHours(4) }
                    }
                },
                new Post
                {
                    Author = "CodeMaster",
                    Title = "Найстрашніший сон розробника: конфлікти міграцій EF Core",
                    Text = "Сидів увечері, налаштовував зв'язки між таблицями. І тут база видає помилку про множинні шляхи каскадного видалення. Здається, налаштування обмежень врятувало мені нервову систему.",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "adrij", Text = "Класика жанру! Краще одразу явно прописувати правила видалення в OnModelCreating.", CreatedAt = DateTime.Now.AddDays(-1).AddHours(1) }
                    }
                },
                new Post
                {
                    Author = "MaxDev",
                    Title = "Чи варто писати коментарі в коді?",
                    Text = "Існує думка, що якісний код має бути настільки самоописовим, що додаткові коментарі йому не потрібні. Але іноді дивишся на свій власний код через місяць і думаєш: «Хто це написав?»",
                    CreatedAt = DateTime.Now.AddHours(-18),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "Olya_K", Text = "Називай змінні нормально — і коментарі не знадобляться. Але для складної бізнес-логіки вони потрібні.", CreatedAt = DateTime.Now.AddHours(-15) }
                    }
                },
                new Post
                {
                    Author = "Engineer22",
                    Title = "Куки чи токени: як краще зберігати сесію користувача?",
                    Text = "Розробляю чергову систему авторизації та постаю перед вибором: використовувати класичні куки з ім'ям користувача чи переходити на сучасні JWT-токени у своєму моноліті?",
                    CreatedAt = DateTime.Now.AddHours(-12),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "CodeMaster", Text = "Для монолітів на MVC куки з HttpOnly — це ідеальний та безпечний варіант.", CreatedAt = DateTime.Now.AddHours(-10) }
                    }
                },
                new Post
                {
                    Author = "Olya_K",
                    Title = "Порада першокурсникам університету: з чого починати?",
                    Text = "Навчання в університеті дає базову теорію з математики та алгоритмів, але реальні навички розробки чомусь доводиться здобувати самостійно ночами за комп'ютером. Що порадите?",
                    CreatedAt = DateTime.Now.AddHours(-6),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "adrij", Text = "Пишіть свої пет-проєкти з першого курсу і викладайте на GitHub. Це дає найбільший скіл.", CreatedAt = DateTime.Now.AddHours(-4) }
                    }
                },
                new Post
                {
                    Author = "adrij",
                    Title = "Де ви шукаєте рішення, коли все ламається?",
                    Text = "У кожного бувають дні, коли ти сидиш над однією помилкою кілька годин поспіль, перепробував уже все, а воно все одно не працює. Як ви перемикаєтеся в таких ситуаціях?",
                    CreatedAt = DateTime.Now.AddHours(-2),
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "MaxDev", Text = "Чашка кави і погляд на проблему свіжим поглядом зазвичай творять дива.", CreatedAt = DateTime.Now.AddHours(-1) },
                        new Comment { Author = "Engineer22", Text = "Метод гумової качки — пояснюєш коту свій код, і одразу бачиш помилку!", CreatedAt = DateTime.Now.AddMinutes(-30) }
                    }
                }
            };

            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
        //==========================AI SEEDER==========================

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
