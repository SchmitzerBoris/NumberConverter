Alle methods in de static class Numerals.cs zijn private. De enige method die de mainwindow rechtstreeks oproept is 'ConvertNumericSystem(...)'. De rest van de methods wordt enkel en alleen opgeroepen om die method te helpen werken.

Kommagetallen en negatieve getallen zijn nog niet geïmplementeerd :'(

Maximum grondtal is 36 (gebruikt alle symbolen 0-9 en A-Z).

In de MainWindow.xaml.cs zit een checkbox om te kiezen of je een getal uit de lijst kiest of zelf een getal invoert.

De logica:

Elk getal in een NIET-10-delig talstelsel wordt opgeslagen als string.

Decimaal wordt altijd als tussenstap gebruikt (buiten enkele uitzonderingen). Reden: met decimaal komen integers overeen, en met integers kan je véél makkelijker wiskundige berekeningen doen dan met characters in een string.

