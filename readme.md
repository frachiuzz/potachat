# Documentazione del Protocollo Potachat

Il protocollo Potachat è progettato per facilitare la comunicazione tra utenti in una rete locale attraverso comandi semplici e diretti. Di seguito, viene descritta la funzionalità di ciascun comando disponibile nel protocollo.

## Comandi del Protocollo

### 1. HELLO
- **Descrizione**: Utilizzato per iniziare una connessione con il server Potachat. Deve essere il primo comando inviato dopo aver stabilito una connessione TCP.
- **Sintassi**: `HELLO`
- **Risposta del Server**: Il server risponderà con `HELLO` come conferma dell'avvenuta connessione.

### 2. NAME
- **Descrizione**: Imposta o richiede il nome utente corrente.
- **Sintassi**:
  - Per impostare il nome: `NAME <nome_utente>`
  - Per richiedere il nome corrente: `NAME`
- **Risposte del Server**:
  - Se il nome viene impostato con successo: `NAME OK`
  - Se viene richiesto il nome corrente: `NAME <nome_utente_attuale>`

### 3. LIST
- **Descrizione**: Richiede l'elenco degli utenti attualmente connessi al server.
- **Sintassi**: `LIST`
- **Risposta del Server**: Il server risponderà con un elenco di indirizzi IP e nomi utente degli utenti connessi. Ogni utente è elencato su una riga separata nel formato `IP NomeUtente`. La fine dell'elenco è marcata con `LIST END`.

### 4. MESSAGE
- **Descrizione**: Invia un messaggio a un singolo utente o a tutti gli utenti.
- **Sintassi**:
  - Per inviare a tutti: `MESSAGE <IP_mittente> ALL <messaggio>`
  - Per inviare a un singolo utente: `MESSAGE <IP_mittente> <IP_destinatario> <messaggio>`
- **Nota**: Il server inoltra il messaggio ai destinatari specificati senza inviare una risposta esplicita al mittente. Gli utenti riceveranno il messaggio nel formato specificato.

### 5. QUIT
- **Descrizione**: Termina la connessione con il server.
- **Sintassi**: `QUIT`
- **Risposta del Server**: Non è prevista una risposta esplicita dal server, ma la connessione verrà chiusa.

## Note Aggiuntive

- Tutti i comandi e le comunicazioni devono seguire una codifica uniforme (ad esempio, UTF-8) per garantire la compatibilità e la corretta ricezione dei messaggi.
- È importante seguire l'ordine corretto dei comandi per assicurare una comunicazione fluida e senza errori. Ad esempio, un utente dovrebbe inviare il comando `HELLO` immediatamente dopo aver stabilito la connessione, seguito dall'impostazione del nome utente tramite `NAME` prima di procedere con altri comandi.
- La sicurezza delle comunicazioni non è specificata in questo documento; gli implementatori possono considerare l'aggiunta di crittografia o altri meccanismi di sicurezza a seconda delle esigenze della rete.

Questo protocollo è progettato per essere semplice ed efficiente, rendendolo ideale per chat di base e comunicazioni in reti locali.
