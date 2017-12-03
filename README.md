# snek.io
C# projekt

## co to za projekt? ##
__Snake__ to gra polegająca na sterowaniu wężem aby zjadać jedzenie by stawać sie coraz dłuższym. Celem jest zdobycie jak najwiecej punktów.
Moim zadaniem jest napisanie takiej gry (+ funkcje online).
___
## jakie ma funkcje? ##
+ Singleplayer mode: gra samemu z wspólnymi dla wszystkich tabelami wyników
+ Multiplayer mode: możliwość grania z innymi na raz
+ Leaderboards: miejsce gdzie można zobaczyć rekordy
___
## jakich rzeczy używam? ##
+ Timer: rytmiczne wykonywanie jakiś zadań
+ Material Design: wizualny standard Google
+ TCP: sockets do szybkiej komunikacji komputerów
+ MySQL: bazadanych do przechowywania rekordów
___
## klasy ##
+ [Snake](./Snake/Snake.cs): prędkość, kolor, wielkość, metody kolizjii
+ [Food](./Snake/Food.cs): lokalizacja, kolor, wartość, metody generowania miejsca pojawienia się
+ [Game](./Snake/Game.cs): parametry gry
+ [MySQL](./Snake/MySQL.cs): polaczenie, wykonanie query, zamknięcie
+ [WaitingRoom](./Snake/WaitingRoom.cs): miejsce gdzie czeka sie na połączenie innych graczy
+ [SinglePlayer](./Snake/SinglePlayer.cs): gra jednoosobowa

___
## TODO ##
- [ ] multiplayer
- [x] prompt room before starting a game on MP
- [x] singleplayer bonus food
- [x] all material design controls
- [ ] leaderboards not local
- [x] fullscreen singleplayer


![picture alt](https://raw.githubusercontent.com/clitcancer/snek.io/master/Snake/favicon_pak_icon.ico "Snek.io")
