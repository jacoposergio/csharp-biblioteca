
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

//Utente utente1 = new("Bianchi", "Antonio", "bianchi@mail.it", "3321234567");
//Utente utente2 = new Utente("Rossi", "Mario", "mario@mail.it", "4443234567");
//Utente utente3 = new Utente("Verdi", "Luca", "verdi@mail.it", "5551334567");

//List<Utente> tuttiGliUtenti = new List<Utente>();
//tuttiGliUtenti.Add(utente1);
//tuttiGliUtenti.Add(utente2);
//tuttiGliUtenti.Add(utente3);

//foreach (Utente item in tuttiGliUtenti)
//{
//    {

//    }

//}



public class Libri : Documenti
{
    public Libri(string id, string titolo, int anno, string settore, bool disponibile, string scaffale, string autore) : base(id, titolo, anno, settore, disponibile, scaffale, autore)
    {
    }

    public int Pagine { get; set; }
 
    
}
