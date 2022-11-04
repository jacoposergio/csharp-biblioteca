
//Richiesta:
//Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario 
// può verificare i dati dei clienti registrati
//cognome,
//nome,
//email,
//recapito telefonico,
//Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il
//sistema, sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//Il bibliotecario deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, 
//effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un cliente.


public class Utente
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public int Recapito { get; set; }

    public Utente(string cognome, string nome, string email, int recapito)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Recapito = recapito;
    }
}

public class Documenti
{
    public string Id { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }

    public bool Stato { get; set; }

    public string Scaffale { get; set; }

    public string Autore { get; set; }

    public Documenti(string id, string titolo, int anno, string settore, bool stato, string scaffale, string autore)
    {
        Id = id;
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
    }
}

public class Libri : Documenti
{
    public int Pagine { get; set; }
    public Libri(string )
}

public class Dvd : Documenti
{
    public int Durata { get; set; }
}