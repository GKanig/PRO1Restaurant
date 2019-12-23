# PRO1Restaurant

Projekt ma posłużyć zaznajomieniu się z tworzeniem API w środowisku .NET

## Baza danych

Przy projekcie wykorzystywana jest baza danych mssql uruchamiana w dockerze. Aby utworzyć i skonfigurować ją poprawnie należy wywołaćponiższą komendę.

```
.\DB\createDBinDocker.ps1
```

Skrypt powienien utworzyć kontener z bazą oraz wykonać skrypty zakłądające schemat bazy wraz z danymi testowymi.