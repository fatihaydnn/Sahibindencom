
ReadMe 
1. SahbindenBitirmeProjesi ad�nda blank solution ekledik.

2. SahbindenBitirmeProjesi.Entity ad�nda Class Library (.Net Core) projesi ekledik.
	2.1. Enums Klas�r� a�t�k.
		2.1.1 Status class�n� olu�turduk.
	2.2. Entities klas�r� a�t�k.
		2.2.1. Interface klas�r� a��ld� ve IBaseEntity.cs s�n�f�n� a�t�k. 
		2.2.2. Concrete klas�r� a�t�k ve ihtiya� duyulan varl�klar� IdentityUser'den miras alarak ve kendimiz ekleyerek ihtiya�lar�m�z� kar��lad�k.
		2.2.3. Extention klas�r� a��ld�, FileExtentionAttribute.cs s�n�f� a��ld�.

3. SahbindenBitirmeProjesi.Map ad�nda Class Library(.Net Core) projesi ekledik.
	3.1. Abstract ad�nda klas�r a�t�k.
		3.1.1. BaseMap.cs class�n� olu�tururuz ve entity katman�nda ki ortak varl�klar� burada mapleriz ve concreteler i�in de birer ata s�n�f� olarak kullan�l�r.
	3.2. Concrete ad�nda klas�r a�t�k.

4. SahbindenBitirmeProjesi.Data ad�ndan Class Library (.Net Core) projesi ekledik.
	4.1. SeedData klas�r� ekledik ve SeedPage.cs ad�nda class a�t�k.
	4.2. Context klas�r� olu�turduk. ApplicationDbContext.cs class�n� olu�turup burada DbSet i�lemleri ve SeedDatam�z� ekleriz.
	4.3. Repository klas�r� a��ld�.
		4.3.1. Interface klas�r� a�t�k.
			4.3.1.1. Base klas�r� a�t�k.
			4.3.1.2. EntityTypeRepositories klas�r� a�t�k.
		4.3.2. Concrete klas�r� a�t�k.
			4.3.2.1. Base klas�r� a�t�k. BaseRepository.cs ekledik.
			4.3.2.2. EntityTypeRepositories klas�r� a�t�k.

5. SahibindenBitirmeProjesi.Web ad�nda Asp .Net Core Web Application projesi ekledik. 
	5.1. Startup.cs'e projede ki ba��ml� s�n�flar� register ettim. Bu sayede kullanaca��m yerde new kullanmak yerine constructor injection sayesinde kullan�ma a�t�k.
	5.2. appsettings.json dosyas�na gidip defaultconnection'�m�z� yazd�k.
	5.3. Migration i�lemi ger�ekle�tirilir.
	5.4. Areas klas�r�n� a�t�k.
		5.4.1. Admin klas�r� a�t�k.(Bu sayede sadece adminin g�rebilece�i �eyleri buraya ekleyece�iz.)
		5.4.2. Startup.cs a giderek adm�n klas�r� i�in endpoint yazd�k.
		5.4.3. Global de bulunan "Shared + _ViewImports + _ViewStart" dosyalar�n� adminin i�ine kopyalad�k.
		5.4.4. CarsController.cs - HomeController.cs - ModelController.cs - PageController.cs - RoleController.cs - UserController.cs classlar� ve gerekenlerin view'lar� eklenip gerekli i�lemler yap�l�r.
	5.5. Models => Components klas�r� a��ld�. MainMenuComponent.cs class� a��l�r. ViewComponent.cs miras al�nd�.
		5.5.1. Shared => Component klas�r� a��ld� => MainMenu klas�r� a��ld� => Default partial view a��l�r.
	5.6. Models => CarsViewComponent.cs class� a��l�r. ViewComponent.cs miras al�nd�.
		5.6.1. Shared => Cars klas�r� a��ld� => Default partial view a��l�r.
	5.7. Models => SmallCartViewComponent.cs class� a��l�r. ViewComponent.cs miras al�nd�.
		5.7.1. Shared => SmallCart klas�r� a��ld� => Default partial view a��l�r.
	5.8. Ekledi�imiz componentlar� _Layout i�erisine uygun bir �ekilde yerle�tirdik.
	5.9. Ekliyece�imiz modeller de Cars bilgilerini �ekebilmemiz i�in gerekli endpointleri Startup.cs class'�n�n i�ine ekledik.
	5.10. Controllers => AccountController.cs a��l�p register login i�lemlerini burada yapt�k. Viewlerini ekledik.
		5.10.1. Edit i�lemleri esnas�nda ihtiyac�m�z olan verileri Models => Dtos klas�r� a��ld� => Login.cs class�nda �bekledik.
	NOT: Register i�lemi i�in veri taban�na gidip "dbo.AspNetUser" tablosunda ki varl�klar� nullable yapt�k.
	NOT2: Built-in container i�erisinde gerekli register ve resolver i�lemini yerine getirin. 
	5.11. Role Management i�lemlerini ger�ekle�tirdik.
		5.11.1. TagHelper klas�r� a��ld� => RoleTagHelper.cs a��ld�. Rolleri listeledi�imizde tekrarlar� engellemek amac�yla yazd�k.
