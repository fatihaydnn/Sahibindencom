
ReadMe 
1. SahbindenBitirmeProjesi adýnda blank solution ekledik.

2. SahbindenBitirmeProjesi.Entity adýnda Class Library (.Net Core) projesi ekledik.
	2.1. Enums Klasörü açtýk.
		2.1.1 Status classýný oluþturduk.
	2.2. Entities klasörü açtýk.
		2.2.1. Interface klasörü açýldý ve IBaseEntity.cs sýnýfýný açtýk. 
		2.2.2. Concrete klasörü açtýk ve ihtiyaç duyulan varlýklarý IdentityUser'den miras alarak ve kendimiz ekleyerek ihtiyaçlarýmýzý karþýladýk.
		2.2.3. Extention klasörü açýldý, FileExtentionAttribute.cs sýnýfý açýldý.

3. SahbindenBitirmeProjesi.Map adýnda Class Library(.Net Core) projesi ekledik.
	3.1. Abstract adýnda klasör açtýk.
		3.1.1. BaseMap.cs classýný oluþtururuz ve entity katmanýnda ki ortak varlýklarý burada mapleriz ve concreteler için de birer ata sýnýfý olarak kullanýlýr.
	3.2. Concrete adýnda klasör açtýk.

4. SahbindenBitirmeProjesi.Data adýndan Class Library (.Net Core) projesi ekledik.
	4.1. SeedData klasörü ekledik ve SeedPage.cs adýnda class açtýk.
	4.2. Context klasörü oluþturduk. ApplicationDbContext.cs classýný oluþturup burada DbSet iþlemleri ve SeedDatamýzý ekleriz.
	4.3. Repository klasörü açýldý.
		4.3.1. Interface klasörü açtýk.
			4.3.1.1. Base klasörü açtýk.
			4.3.1.2. EntityTypeRepositories klasörü açtýk.
		4.3.2. Concrete klasörü açtýk.
			4.3.2.1. Base klasörü açtýk. BaseRepository.cs ekledik.
			4.3.2.2. EntityTypeRepositories klasörü açtýk.

5. SahibindenBitirmeProjesi.Web adýnda Asp .Net Core Web Application projesi ekledik. 
	5.1. Startup.cs'e projede ki baðýmlý sýnýflarý register ettim. Bu sayede kullanacaðým yerde new kullanmak yerine constructor injection sayesinde kullanýma açtýk.
	5.2. appsettings.json dosyasýna gidip defaultconnection'ýmýzý yazdýk.
	5.3. Migration iþlemi gerçekleþtirilir.
	5.4. Areas klasörünü açtýk.
		5.4.1. Admin klasörü açtýk.(Bu sayede sadece adminin görebileceði þeyleri buraya ekleyeceðiz.)
		5.4.2. Startup.cs a giderek admþn klasörü için endpoint yazdýk.
		5.4.3. Global de bulunan "Shared + _ViewImports + _ViewStart" dosyalarýný adminin içine kopyaladýk.
		5.4.4. CarsController.cs - HomeController.cs - ModelController.cs - PageController.cs - RoleController.cs - UserController.cs classlarý ve gerekenlerin view'larý eklenip gerekli iþlemler yapýlýr.
	5.5. Models => Components klasörü açýldý. MainMenuComponent.cs classý açýlýr. ViewComponent.cs miras alýndý.
		5.5.1. Shared => Component klasörü açýldý => MainMenu klasörü açýldý => Default partial view açýlýr.
	5.6. Models => CarsViewComponent.cs classý açýlýr. ViewComponent.cs miras alýndý.
		5.6.1. Shared => Cars klasörü açýldý => Default partial view açýlýr.
	5.7. Models => SmallCartViewComponent.cs classý açýlýr. ViewComponent.cs miras alýndý.
		5.7.1. Shared => SmallCart klasörü açýldý => Default partial view açýlýr.
	5.8. Eklediðimiz componentlarý _Layout içerisine uygun bir þekilde yerleþtirdik.
	5.9. Ekliyeceðimiz modeller de Cars bilgilerini çekebilmemiz için gerekli endpointleri Startup.cs class'ýnýn içine ekledik.
	5.10. Controllers => AccountController.cs açýlýp register login iþlemlerini burada yaptýk. Viewlerini ekledik.
		5.10.1. Edit iþlemleri esnasýnda ihtiyacýmýz olan verileri Models => Dtos klasörü açýldý => Login.cs classýnda öbekledik.
	NOT: Register iþlemi için veri tabanýna gidip "dbo.AspNetUser" tablosunda ki varlýklarý nullable yaptýk.
	NOT2: Built-in container içerisinde gerekli register ve resolver iþlemini yerine getirin. 
	5.11. Role Management iþlemlerini gerçekleþtirdik.
		5.11.1. TagHelper klasörü açýldý => RoleTagHelper.cs açýldý. Rolleri listelediðimizde tekrarlarý engellemek amacýyla yazdýk.
