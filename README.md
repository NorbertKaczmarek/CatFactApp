
# CatFactApp

Konsolowa aplikacja, która ³¹czy siê z publicznym endpointem:
```
  https://catfact.ninja/fact
```

Mapuje pobran¹ odpowiedŸ do **CatFact** 
| Parametr  | Typ      | Opis                              |
| :-------- | :------- | :-------------------------------- |
| `Fact`    | `string` | Losowy fakt zwi¹zany z kotami.    |
| `Length`  | `int`    | D³ugoœæ faktu.                    |

Nastêpnie zapisuje j¹ w pliku tekstowym:
```
  CatFacts.txt
```

