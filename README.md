
# CatFactApp

Konsolowa aplikacja, kt�ra ��czy si� z publicznym endpointem:
```
  https://catfact.ninja/fact
```

Mapuje pobran� odpowied� do **CatFact** 
| Parametr  | Typ      | Opis                              |
| :-------- | :------- | :-------------------------------- |
| `Fact`    | `string` | Losowy fakt zwi�zany z kotami.    |
| `Length`  | `int`    | D�ugo�� faktu.                    |

Nast�pnie zapisuje j� w pliku tekstowym:
```
  CatFacts.txt
```

