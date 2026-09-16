**Dátum:** 2025. szeptember 5., péntek 13:00 **Oktató:** Dr. Szőke Magdolna **Téma:** Számrendszerek

> Megjegyzés: ez a jegyzet a Teams-felvétel OneNote-tábláján leírtak alapján készült (a felvétel hangsávját technikai okokból — a sandbox hálózati korlátozásai miatt — nem sikerült feldolgoznom). Ha valahol az élőszóban elhangzott kiegészítés hiányzik, érdemes a Class Notebookot / a felvételt is megnézni.

---

## 1. Adminisztráció, követelmények

- **Hiányzás:** legfeljebb ≤30% engedélyezett.
- **Óraszám:** 2+3 (elmélet + gyakorlat, feltehetően).
- **Zárthelyik:** 2 db, 2 zárthelyi dolgozat.
- **Villámkérdések:** minden héten a Moodle-ba feltöltve, hetente 3 kérdés, 2 pont/kérdés → 10 hét × 2 pont.
- A félévi pontszámból **≥50 pont** szükséges az **aláíráshoz** / a vizsgára bocsáthatósághoz. Aláírás megtagadása esetén a félév nem fogadható el (pótlási lehetőségekről a Moodle-on / oktatótól érdemes tájékozódni, ez a rész a táblán nehezen volt olvasható).
    
- **Vizsgaidőszak:** vizsga = **írásbeli beugró → szóbeli vizsga**.
    - Írásbeli (IB): 30 pont (12 pont elmélet + 18 pont feladat), teljesítéshez kb. ≥15 pont szükséges.
    - Szóbeli (SzB): 40 pont, teljesítéshez kb. ≥20 pont szükséges.
- **Hozott pont** = 0,3 × félévközi teljesítmény (kb. 15–30 pont közötti tartományban).
- **Érdemjegy-skála (0–100 pont alapján):**
    |Pontszám|Jegy|
    |---|---|
    |0–49|1|
    |50–61|2|
    |62–73|3|
    |74–85|4|
    |86–100|5|
- **Zárthelyik formája:** 1. ZH – elektronikus, 2. ZH – papíros.

---

## 2. Számrendszerek – alapok

### 2.1 Helyiértékes (pozíciós) felírás – 10-es számrendszer

Példa: `n = 3419`

```
n = 3·1000 + 4·100 + 1·10 + 9·1
  = 3·10³ + 4·10² + 1·10¹ + 9·10⁰
```

(Ezres, Százas, Tízes, Egyes helyiértékek.)

Számjegyek a 10-es rendszerben: `0, 1, 2, …, 9`, azaz `9 = 10 − 1`.

### 2.2 Általános, _a_ alapú számrendszer

Egy _a_ alapú szám (`a_k a_{k-1} … a_1 a_0`) helyiértékes alakja:

```
n = a_k·a^k + a_{k-1}·a^(k-1) + … + a_1·a + a_0
```

ahol a számjegyek: `0, 1, …, a-1`.

---

## 3. Átváltás 10-es alapról más alapra

### 3.1 Horner-elrendezés (átalakítás egymásba ágyazott szorzat alakra)

```
n = a_k·a^k + a_{k-1}·a^(k-1) + … + a_1·a + a_0
  = (a_k·a^(k-1) + … + a_1)·a + a_0
  = ((…(a_k·a + a_{k-1})·a + … + a_2)·a + a_1)·a + a_0
```

Ellenőrző példa: `162` szám 7-es számrendszerben:

```
162₍₇₎ = (1·7 + 6)·7 + 2
```

Ebből adódik az **osztásos algoritmus**:

- `a_0` = az `n` szám `a`-val vett **osztási maradéka**
- `a_1` = az előző **hányados** `a`-val vett osztási maradéka
- … és így tovább, amíg a hányados 0 nem lesz.

A jegyeket a maradékokból **alulról felfelé olvasva** kapjuk meg.

### 3.2 Végigszámolt példa: `3419` (10-es) → 7-es számrendszer

```
3419 : 7 = 488, maradék 3   →  a₀ = 3
 488 : 7 =  69, maradék 5   →  a₁ = 5
  69 : 7 =   9, maradék 6   →  a₂ = 6
   9 : 7 =   1, maradék 2   →  a₃ = 2
   1 : 7 =   0, maradék 1   →  a₄ = 1
```

Maradékok alulról felfelé: **3419₍₁₀₎ = 12653₍₇₎**

(A jegyzetben ezt utólag hagyományos írásbeli osztással is leellenőrizték: `3419 : 7 = 488`, majd tovább osztva `69`, `9`, `1` – ugyanaz az eredmény jön ki.)

---

## 4. Hexadecimális (16-os) számrendszer és „gyors” átváltás

- Alap: `a = 16`
- Számjegyek: `A=10, B=11, C=12, D=13, E=14, F=15`

**„Gyors" átváltás szabálya:** ha a két alap között `b = a^k` (vagy fordítva) összefüggés áll fenn, akkor a jegyeket egyszerű **csoportosítással** lehet átváltani, nem kell osztogatni:

- **2 ↔ 16** (16 = 2⁴): 4 bit = 1 hexa jegy
- **2 ↔ 8** (8 = 2³): 3 bit = 1 oktális jegy

**Példa:** `A1E₍₁₆₎` binárisan, jegyenként 4 biten:

```
A = 1010,  1 = 0001,  E = 1110
A1E₍₁₆₎ = 1010 0001 1110₍₂₎
```

Ugyanezt a bitsorozatot 3-as csoportokra bontva megkapjuk az oktális, 4-es csoportokra bontva a hexa alakot – ez az elv fordítva (kettesből másik alapba) is működik.

---

## 5. Bináris alapműveletek

Ugyanazok a szabályok, mint a 10-es számrendszerben, csak a „váltás" 2-nél történik (nem 10-nél).

**Összeadás**, példa:

```
   1101
 +10111
-------
 11100
```

**Kivonás** (kölcsönzéssel/átvitellel, ugyanúgy mint 10-esben):

```
  101110
 - 01111
--------
  ...
```

**Szorzás** (eltolásos-összeadásos módszer, mint a papíron végzett szorzás):

```
Példa: 1011111 · 11 = 10111110
```

Minden szorzójegyre (0 vagy 1) egy eltolt részletösszeget kapunk (0 vagy maga a szorzandó), ezeket összeadva jön ki az eredmény.

**Osztás** (írásbeli osztás mintájára):

```
Példa: 101101 : 110 = 111, maradékkal
```

---

## 6. Törtszámok átváltása

### 6.1 Általános alak

```
n = (a_k … a_1 a_0 , a₋₁ a₋₂ … a₋ₗ)_a
  = a_k·a^k + … + a_0  +  (a₋₁·a⁻¹ + a₋₂·a⁻² + … + a₋ₗ·a⁻ˡ)
```

A törtrész mindig `< 1`.

### 6.2 Átváltási algoritmus (szorzásos módszer)

A tizedes törtrészt ismételten **megszorozzuk az új alappal (a)**; minden lépésben az **egészrész** adja a következő jegyet, a maradék törtrésszel folytatjuk.

```
törtrész · a  →  egészrész = következő jegy, maradék törtrésszel tovább
```

### 6.3 A végeredmény három esete

- **véges** tizedestört
- **végtelen szakaszos** → **racionális** szám
- **végtelen, nem szakaszos** → **irracionális** szám

(Fontos, hogy egy adott tört attól függően lehet véges vagy végtelen, hogy melyik számrendszerben írjuk fel – pl. a 10-es rendszerben véges `0,1` a kettes számrendszerben végtelen szakaszos tört.)

---

## 7. Egész számok gépi ábrázolása (n biten)

Példa: **16 biten**, `n = 1312`.

**1312 átváltása 2-es számrendszerbe** (osztásos módszerrel):

```
1312 : 2 = 656, maradék 0
 656 : 2 = 328, maradék 0
 328 : 2 = 164, maradék 0
 164 : 2 =  82, maradék 0
  82 : 2 =  41, maradék 0
  41 : 2 =  20, maradék 1
  20 : 2 =  10, maradék 0
  10 : 2 =   5, maradék 0
   5 : 2 =   2, maradék 1
   2 : 2 =   1, maradék 0
   1 : 2 =   0, maradék 1
```

→ **1312₍₁₀₎ = 10100100000₍₂₎**

**16 biten való tárolás:** 1 **előjelbit** + a maradék bitek a **szám (abszolútérték)** számára, a magasabb helyiértékű biteket 0-kal feltöltve (pozitív szám esetén az előjelbit 0).

**Negatív szám (−1312) ábrázolása – kettes komplemens képzés:**

1. vesszük a pozitív szám (+1312) bitmintáját
2. **minden bitet invertálunk** (0↔1)
3. az eredményhez **hozzáadunk 1-et**

Ez adja a −1312 kettes komplemens alakú, gépi ábrázolását.

---

## 8. Lebegőpontos (float) ábrázolás

**Normálalak** (tudományos alak), decimális analógiával bevezetve:

```
-7,91 · 10⁵
 8,1002 · 10⁻⁷
```

**32 bites felosztás:** `32 = 1 + 8 + 23` bit, azaz:

- 1 bit: **előjel**
- 8 bit: **kitevő (karakterisztika)**
- 23 bit: **mantissza**

_(Ez lényegében a szabványos, egyszeres pontosságú lebegőpontos ábrázolás – „IEEE 754 single precision" – felépítése, ha esetleg ezzel a névvel is találkozol később.)_

### Végigszámolt példa: `13,41₍₁₀₎`

1. **Egész rész átváltása:** `13₍₁₀₎ = 1101₍₂₎`
2. **Törtrész átváltása** a 6. pontban leírt szorzásos módszerrel (folytatva: `…1010 0110 1…`)
3. **Normálás:** a bináris alakot `1,xxxxx · 2^k` alakra hozzuk (a tizedesvesszőt addig toljuk, amíg az első jegy előtt csak egy 1-es marad) → a kapott kitevő itt `2³`
4. **Kitevő eltolása (bias):** a tényleges kitevőhöz hozzáadjuk a torzítást (**127**): `3 + 127 = 130`
    - `130₍₁₀₎ = 10000010₍₂₎` → ez kerül a 8 bites kitevő-mezőbe
5. **Mantissza:** a normált alak tizedesvessző utáni jegyei kerülnek a 23 bites mantissza-mezőbe (a vezető `1`-est nem kell eltárolni, hiszen az mindig ott van)

Végeredmény vázlatosan: `[előjel: 0][kitevő: 10000010][mantissza: 1010011010…]`