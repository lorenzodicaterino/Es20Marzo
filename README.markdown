# Esercitazione 20 Marzo

```sql
CREATE TABLE utente(
utenteID INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(250) NOT NULL,
cognome VARCHAR(250) NOT NULL,
email VARCHAR(250) NOT NULL
);

CREATE TABLE libro(
libroID INT PRIMARY KEY IDENTITY(1,1),
titolo VARCHAR(250) NOT NULL,
anno_di_pubblicazione DATE NOT NULL,
disponibile BIT NOT NULL
);

CREATE TABLE prestito(
prestitoID INT PRIMARY KEY IDENTITY(1,1),
data_prestito DATE NOT NULL,
data_restituzione DATE,
libroRIF INT NOT NULL,
utenteRIF INT NOT NULL,
FOREIGN KEY (libroRIF) REFERENCES libro(libroID) ON DELETE CASCADE,
FOREIGN KEY (utenteRIF) REFERENCES utente(utenteID) ON DELETE CASCADE
);
```

Per tempistiche mi sono fermato alle operazioni di CRUD sul database tramite C#. Ho avuto alcuni problemi per quanto riguarda l'insert dell'oggetto Prestito quando la variabile DataRestituzione veniva settata a null. Ho inoltre implementato alcuni metodi aggiuntivi, quali GetByUtente, GetByLibro e GetByLibroUtente. Nei prossimi giorni verranno implementate tutte le caratteristiche richieste da traccia. 
