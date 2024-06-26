    Alien Licence

**Главное Меню.**

Точка входа приложения, где инициализируются необходимые на других сценах объекты, сохранения остаются в пределах одной игровой сессии, при перезаходе сохранения очищаются. Здесь можно нажать играть и перейти к уровням или выйти с игры.

**Список Уровней.**

Список уровней помещен в контейнер, который заполняется уровнями в зависимости от их количества. Каждый уровень изначально помечен как не пройденный, и если игрок проходит его, то уровень загорается зеленым цветом. Пройденные уровни, также можно проходить повторно.

**Уровни.**

Уровни создаются вручную, но часть логики автоматизирована с помощью объекта GridManager. Это позволяет создавать комнаты определенных размеров со стенами по периметру. Если в будущем будет возможно переделывать создание комнат, беря данные из файлов _Excel_ или _TXT_, то можно будет задавать позиции вспомогательных зон и дверей для выхода, запарсив документ.

**Свайпы**

Свайпы на уровнях реализованы двумя вариантами:

1. Объекты движутся по двум осям, но только в одном направлении за один свайп. На этой логике я создавал уровни. Метод – DetermineDirectionTwoAxis.
2. Если нужно реализовать свайп объектов только по одной оси. Чтобы это работало, каждому объекту мебели нужно задать направление движения в Enum. Метод – DetermineDirectionOneAxis

Свайпы также работают если предмет упирается в другой предмет, в дальнейшем можно добавить анимацию удара для визуализации этого.

Если любой двигающийся предмет касается «_будящего предмета_», человек просыпается, пробуждающий предмет (часы) помечен красным цветом.

Если игрок помещает предмет во вспомогательную «_зону света_», то предмету нужно простоять в этой зоне n секунд, прежде чем его заберут, предметы которые могут забирать помечены желтой обводкой.
