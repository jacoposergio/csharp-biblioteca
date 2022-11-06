
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

using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

Biblioteca mondadori = new Biblioteca();
mondadori.AvviaBiblioteca();

Console.WriteLine("Digita 1 per cercare un documento");
Console.WriteLine("Digita 2 per cercare un prestito");
Console.WriteLine("Digita 3 per registrare un nuovo prestito");
int risposta = Convert.ToInt32(Console.ReadLine());

switch (risposta)
{
    case 1:
        mondadori.CercaTuttiDocumenti();
        mondadori.CercaDocumento();
        break;
    case 2:
        mondadori.CercaPrestito();
        break;
    case 3:
        mondadori.RegistraPrestito();
        break;
    default:
        Console.WriteLine("Sei capace di premere un tasto?");
        break;
}

//mondadori.CercaTuttiDocumenti();
//mondadori.CercaTuttiPrestiti();
//mondadori.CercaPrestito();
//mondadori.RegistraUtente();
//mondadori.CercaDocumento();
//mondadori.RegistraPrestito();
//mondadori.StampaPrestiti();



public class Biblioteca
{
    public List<Utente> tuttiGliUtenti = new List<Utente>();
    public List<Documenti> tuttiIDocumenti = new List<Documenti>();
    public List<Prestito> tuttiIPrestiti = new List<Prestito>();

    //Utenti
    public void AvviaBiblioteca()
    {
        //utenti
        Utente utente1 = new Utente("Rossi", "Mario", "ross@email.it", "3382021234");
        Utente utente2 = new Utente("Verdi", "Antonio", "verdi@email.it", "3222021244");
        Utente utente3 = new Utente("Bianchi", "Luca", "bianchi@email.it", "3382736234");
        tuttiGliUtenti.Add(utente1);
        tuttiGliUtenti.Add(utente1);
        tuttiGliUtenti.Add(utente1);

        //documenti
        Documenti documento1 = new Libri("ISBN 3526372", "IT", 1987, "4b/17", false , "2", "Stephen King", 230);
        Documenti documento2 = new Libri("ISBN 3712571", "I Malavoglia", 1881, "9h/12", true, "12", "Giovanni verga", 120);
        Documenti documento3 = new Libri("34342167127", "Taxi Driver", 1976, "4k/22", true, "10", "Martin Scorsese", 140);
        Documenti documento4 = new Dvd("43316162234", "Alien", 1979, "6u/09", true, "15", "Ridley Scott", 180);
        tuttiIDocumenti.Add(documento1);
        tuttiIDocumenti.Add(documento2);
        tuttiIDocumenti.Add(documento3);
        tuttiIDocumenti.Add(documento4);

        //prestiti
        Prestito prestito1 = new Prestito( utente1, documento1 , "26/03/2022", "21/04/2022");
        Prestito prestito2 = new Prestito(utente2, documento2, "08/03/2022", "15/04/2022");
        Prestito prestito3 = new Prestito(utente3, documento3, "22/01/2022", "15/12/2022");
        Prestito prestito4 = new Prestito(utente3, documento4, "11/09/2022", "14/09/2022");

        tuttiIPrestiti.Add(prestito1);
        tuttiIPrestiti.Add(prestito2);
        tuttiIPrestiti.Add(prestito3);
        tuttiIPrestiti.Add(prestito4);
    }

    ////funzione per cercare documenti
    public void CercaTuttiDocumenti()
    {
        bool isEmpty = !tuttiIDocumenti.Any();
        if (!isEmpty)
        {
            Console.WriteLine("Tutti i documenti: \r\n ");
            foreach (Documenti item in tuttiIDocumenti)
            {
                Console.WriteLine("L'articolo " + item.Titolo + " si trova al settore " + item.Settore + ", scaffale " + item.Scaffale + ", codice " + item.Id + ".");
                if (item.Disponibile == true)
                {
                    Console.WriteLine("Stato: Disponibile \r\n ");
                }
                else
                {
                    Console.WriteLine("Stato: Non disponibile \r\n");
                }
            }
        }
        else
        Console.WriteLine("nessun documento trovato");
    }

    public void CercaTuttiGliUtenti()
    {
        bool isEmpty = !tuttiGliUtenti.Any();
        if (!isEmpty)
        {
            Console.WriteLine(" \r\n Questi sono tutti gli utenti registrati: ");
            foreach (Utente item in tuttiGliUtenti)
            {
                Console.WriteLine(item.Nome + " " + item.Cognome);              
            }
            Console.WriteLine("\r\n");
        }
       
    }

    public void CercaDocumento()
    {
        Console.WriteLine("Inserisci titolo o Id del documento da cercare");
        string documentoRicercato = Console.ReadLine();

        foreach (Documenti item in tuttiIDocumenti )
        {
            if (item.Titolo == documentoRicercato || item.Id == documentoRicercato)
            {
                Console.WriteLine(" \r\n L'articolo " + item.Titolo + " si trova al settore " + item.Settore + ", scaffale " + item.Scaffale + ".");
                if (item.Disponibile == true)
                {
                    Console.WriteLine("Stato: Disponibile \r\n");
                }
                else
                {
                    Console.WriteLine("Stato: Non disponibile \r\n");
                    foreach (Prestito element in tuttiIPrestiti)
                    {
                        if (element.Documenti.Titolo == item.Titolo)
                        {
                            Console.WriteLine("Prestato a" +
                                ": " + element.Utente.Nome + " " + element.Utente.Cognome);
                            Console.WriteLine("Data inizio prestito: " + element.Inizio);
                            Console.WriteLine("Data inizio prestito: " + element.Fine + "\r\n");
                        }
                    }

                }

            }
        }
    }

    public void CercaTuttiPrestiti()
    {
        bool isEmpty = !tuttiIPrestiti.Any();
        if (!isEmpty)
        {
            Console.WriteLine("Tutti i prestiti: \r\n ");
            foreach (Prestito item in tuttiIPrestiti)
            {
                Console.WriteLine("Titolo documento: " + item.Documenti.Titolo );
                Console.WriteLine("Id: " + item.Documenti.Id);
               
                if (item.Documenti.Disponibile == true)
                {
                    Console.WriteLine("Stato: Disponibile \r\n");
                }
                else
                {
                    Console.WriteLine("Stato: Non disponibile");
                    Console.WriteLine("Prestato a: " + item.Utente.Nome + " " + item.Utente.Cognome);
                    Console.WriteLine("Data inizio prestito: " + item.Inizio);
                    Console.WriteLine("Data fine prestito: " + item.Fine  + "\r\n");
                }
            }
        }
        else
            Console.WriteLine("nessun documento trovato");
    }

    public void CercaPrestito()
    {
        Console.WriteLine("Inserisci nome e cognome dell'utente a cui è stato fatto il prestito");
        string prestitoRicercato = Console.ReadLine();

        foreach (Prestito item in tuttiIPrestiti)
        {
            if (prestitoRicercato == item.Utente.Nome + " " + item.Utente.Cognome)
            {
                Console.WriteLine("\r\nTitolo documento: " + item.Documenti.Titolo);
                Console.WriteLine("Id: " + item.Documenti.Id);
                Console.WriteLine("Prestato a: " + item.Utente.Nome + " " + item.Utente.Cognome);
                Console.WriteLine("Data inizio prestito: " + item.Inizio);
                Console.WriteLine("Data inizio prestito: " + item.Fine + "\r\n");
            }
        }
    }

    public void RegistraUtente()
    {
        Console.WriteLine("Inserisci cognome: ");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Inserisci numero telefonico: ");
        string telefono = Console.ReadLine();


        Utente utente = new Utente( cognome , nome, email, telefono );
        tuttiGliUtenti.Add(utente);
        CercaTuttiGliUtenti();
    }


    public void RegistraPrestito()
    {
        Console.WriteLine("Inserisci titolo o Id del documento da cercare");
        string documentoRicercato = Console.ReadLine();

        foreach (Documenti item in tuttiIDocumenti )
        {
            if (item.Titolo == documentoRicercato || item.Id == documentoRicercato)
            {
                Console.WriteLine("L'articolo " + item.Titolo + " si trova al settore " + item.Settore + ", scaffale " + item.Scaffale + ".");
                if (item.Disponibile == true)
                {
                    Console.WriteLine("Stato: Disponibile");
                    Console.WriteLine("\r\n Vuoi prendere in prestito il documento? s/n \r\n");
                    string risposta = Console.ReadLine();
                    if(risposta == "s")
                    {
                        RegistraUtente();
                        Console.WriteLine("Scegli data riconsegna (in questo formato \"dd/MM/yyyy\") : ");
                        string finePrestito = Console.ReadLine();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string inizioPrestito = dateTime.ToString("dd/MM/yyyy");

                        Prestito prestito = new Prestito(tuttiGliUtenti.Last() , item, inizioPrestito, finePrestito);
                        tuttiIPrestiti.Add(prestito);
                        item.Disponibile = false;
                        CercaTuttiPrestiti();
                    }


                }
                else
                {
                    Console.WriteLine("Stato: Non disponibile");
                }

            }
        }
    }


}
