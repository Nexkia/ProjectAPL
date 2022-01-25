using System;

namespace APL.Controlli
{
    internal class CheckFields
    {
        public string CheckRegister(string nomeUtente1, string email1, string indirizzo1, string inserisciPassword1, string confermaPassword1)
        {
            string nomeUtente = nomeUtente1;
            string emailR = email1;
            string indirizzo = indirizzo1;
            string inserisciPasswordR = inserisciPassword1;
            string confermaPasswordR = confermaPassword1;

            if (nomeUtente != string.Empty && emailR != string.Empty && indirizzo != string.Empty &&
                inserisciPasswordR != string.Empty && confermaPasswordR != string.Empty)
            {
                //controllo sul nome utente, che non deve avere spazi
                bool isValidNomeUtente = nomeUtente.Contains(" ");
                bool isValidEmailR = emailR.Contains(" ");
                bool isValidIndirizzo = indirizzo.Contains(" ");
                bool isValidinserisciPasswordR = inserisciPasswordR.Contains(" ");
                bool isValidconfermaPasswordR = confermaPasswordR.Contains(" ");
                if (isValidNomeUtente || isValidEmailR
                    || isValidinserisciPasswordR || isValidconfermaPasswordR || isValidIndirizzo)
                {
                    return "Togliere gli spazi all'interno dei campi";
                }
                else
                {
                    //controllo formato email
                    bool isValidEmailR1 = emailR.Contains("@");
                    bool isValidEmailR2 = emailR.Contains(".");
                    if (!isValidEmailR1 || !isValidEmailR2)
                    {
                        return "Email non valida";
                    }
                    else
                    {
                        //controlla che le due password siano uguali
                        if (inserisciPasswordR != confermaPasswordR)
                        {
                            return "Le due password inserite sono diverse";
                        }
                        else
                        {

                            return "Registrazione avvenuta correttamente";
                        }
                    }
                }
            }
            else
            {
                return "Riempire tutti i campi";
            }
        }

        public string CheckLogin(String email1, String password1)
        {
            String email = email1;
            String password = password1;
            if (email != string.Empty && password != string.Empty)
            {
                bool isValidEmail1 = email.Contains("@");
                bool isValidEmail2 = email.Contains(".");
                if (!isValidEmail1 || !isValidEmail2)
                {
                    return "Email non valida";
                }
                else
                {
                    return "Login effettuato correttamente";
                }
            }
            else
            {
                return "Riempire tutti i campi";
            }
        }
    }
}
