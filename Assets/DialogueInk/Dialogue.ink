INCLUDE globals.ink
{secim == "": -> main | -> already_chose }
=== main ===
Göreve Başlamak İster Misin ? 
    +[Evet] 
        -> chosen ("Evet")
    +[Hayır]
        -> chosen ("Hayır")
        
=== chosen (cevap) === 
~ secim = cevap 
Bunu Sectin {cevap}!
-> END 

=== already_chose ===
Seçimi yaptın {secim}! 
-> END