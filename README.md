# ProgGUIWinForms

Программа разработана в качестве учебного задания по дисциплине "*Разработка графических интерфейсов наукоемкого программного обеспечения*".

Лабораторная работа на **WinForms**.

## Содержание
- [ProgGUIWinForms](#progguiwinforms)
  - [Содержание](#содержание)
  - [Принцип работы программы](#принцип-работы-программы)
  - [Особенности программы](#особенности-программы)
  - [Autobinding координат](#autobinding-координат)
  - [Авторы](#авторы)

## Принцип работы программы

При запуске Вас встречает рабочая область с органами управления программы.

Для начала воспользультесь фукцией загруки *\*.csv* файла, нажав на кнопку **Upload**.

На центральной панели появилась таблица с данными для привязки. Добавить точки Вы можете с помощью кнопки **Add**, введя в появившейся строке *X* и *Y* координаты в соответствующие ячейки.

Для отрисовки графика (*когда будут заданны хотя бы две точки*) выберите вид спрайта и нажмите на кнопку **Draw**.

В представленной программе реализовано два вида спрайтов отрисовки графика: *Линией* и *Сплайном*. Выбрать конкретный вид отрисовки, Вы можете с помощью выпадающего меню. если конкретный вид отрисовки не будет выбран, то **по-умолчанию** выберется отрисовка линией.

После работы с графиком, Вы можете сохранить набор точек в *\*.csv* файл с помощью кнопки **Save**.

## Особенности программы

Вы можете работать сразу с несколькими графиками одновременно.

Для этого загрузите несколько файлов, их перечисление Вы увидите на панели справа.

При выборе файла, его данные будут отображены на центральной панели, а при нажатии на кнопку рисования на левой панели будут отрисованы оба графика одновременно.

Вид спрайта рисования влияет на отрисовку всех графиков сразу.

Кнопка сохранения сохраняет только выбранный в правой панели файл.

## Autobinding координат

Программа поддерживает **автоматическую отрисовку** графика/-ов при изменении их координат.

Для активации этого режима переключите сборку с `Debug` или `Release` в `ReleaseAutoBinding`.

При запуске программы, в режиме автоматической отрисовки, под графической панелью загорится надпись, оповещающая, что режим активирован, а кнопка **Draw** пропадет за ненадобностью.

После загрузки файла график автоматически будет отрисован на графической панели, а любое изменение в таблице с данными приведет к его перерисовке после подтверждения изменений (*после снятии фокуса с редактируемой ячейки*).

Выбор другого спрайта так же автоматически перерисовывает график.

## Авторы

- Барсуков Михаил ПММ-32
- Юзяк Марина ПММ-32
- Федосеев Ярослав ПММ-32
