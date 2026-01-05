# Pet Health History

Aplikacja do śledzenia historii zdrowia zwierząt domowych, stworzona jako projekt zaliczeniowy z Programowania Obiektowego.

Autor: Olga Tomaszewska (31912)

## Funkcjonalności

- Zarządzanie listą zwierząt (dodawanie, edycja, usuwanie)
- Rejestrowanie różnych zdarzeń medycznych:
    - Wizyty lekarskie
    - Zabiegi
    - Wyniki badań laboratoryjnych
- Przeszukiwanie historii zdrowia zwierzęcia
- Losowanie ciekawostek o danym gatunku zwierzęcia

## Wymagania projektowe

1. **Instrukcje warunkowe**: Wykorzystane do walidacji danych i sterowania logiką aplikacji (np. `if`, `switch`)
2. **Pętle**: Wykorzystane do wyświetlania list danych i przetwarzania kolekcji (np. `@foreach`)
3. **Kolekcje generyczne**: Wykorzystanie `ICollection<T>`, `List<T>`, `IEnumerable<T>` do przechowywania relacji i danych
4. **Filary obiektowości**:
    - **Dziedziczenie**: Hierarchia klas zwierząt (`Pet` <- `Dog`, `Cat` itp.) oraz zdarzeń (`Event` <- `Visit` <- `Procedure`)
    - **Polimorfizm**: Nadpisywanie metod wirtualnych i abstrakcyjnych (np. `Search`, `FunFacts`, `PetType`)
    - **Hermetyzacja**: Wykorzystanie modyfikatorów dostępu, właściwości z logiką walidacji
5. **Baza danych**: Dane przechowywane w bazie SQLite przy użyciu Entity Framework
6. **Interfejs użytkownika**: Aplikacja webowa zbudowana w technologii Blazor
7. **Klasy abstrakcyjne**: Klasy bazowe `Pet` i `Event` są abstrakcyjne, co zapewnia spójną strukturę
8. **LINQ**: Wykorzystane do filtrowania i sortowania danych (np. `.Where()`, `.OrderByDescending()`, `.Select()`)

## Uruchomienie

Aby uruchomić aplikację, wymagany jest zainstalowany .NET SDK 10.0.

```bash
dotnet run
```
