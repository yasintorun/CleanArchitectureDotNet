# Application Katmanı

Bu katmanda, projedeki mantıksal, doğrulama gibi işlerin yapıldığı katmandır.

Clean Architecture CQRS yapısını baz alır. Command ve Queries klasörleri içerisinde dış katmanlar için bir giriş ve çıkışları oluşturur.

Command ve Query'lerde mantıksal işlemler yapılabilir, fakat direkt olarak repository referans alıp, veritabanı işlemi gerçekleştiremez.
Bunu yapabilmek için, application katmanında yer alan Service sınıflarından yararlanır.