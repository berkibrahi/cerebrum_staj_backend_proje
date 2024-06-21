Projeyi AspNet core web api ile yaptım ve Onion Architecture yapısını kullandım
Temel İlke: Onion Architecture, iç içe geçmiş bileşenler yerine, katmanları hiyerarşik olarak düzenler. İş mantığı en iç katmanda bulunur ve dışarıya doğru yayılır.

Katmanlar:

Domain Model Katmanı: İş mantığının temelini oluşturan katmandır. Uygulamanın çekirdek işlevselliğini tanımlar ve genellikle bağımsız olarak test edilebilir.
Application Services Katmanı: İş mantığını kullanarak uygulama seviyesinde servisler sağlar. Bu katman, kullanıcı girişi veya dış sistemlerle iletişim gibi işlemleri yönetir.
Infrastructure Katmanı: Veritabanı erişimi, ağ iletişimi, dış hizmet entegrasyonları gibi altyapı detaylarını yönetir.
Presentation Katmanı: Kullanıcı arayüzü ve kullanıcıyla etkileşim sağlayan diğer bileşenleri içerir.
Bağımlılıkların Yönetimi: Onion Architecture'de katmanlar içe doğru bağımlıdır. Yani, iç katmanlar dış katmanlara bağımlı olabilir ancak dış katmanlar iç katmanlara bağımlı olamaz. Bu, katmanların yüksek bağımsızlık ve yeniden kullanılabilirlik sağlamasını amaçlar.

Test Edilebilirlik: Her bir katman, diğer katmanlardan izole edilebilir şekilde tasarlanmalıdır. Bu sayede, bir katmandaki değişikliklerin diğer katmanlara etkisi minimum düzeyde olur ve birim testler kolayca yazılabilir.

Onion Architecture, özellikle büyük ölçekli ve kompleks uygulamalar için uygun bir seçenek olabilir çünkü katmanlar arasındaki net sınırlar, kodun bakımını ve genişletilmesini kolaylaştırır.

Projenin demo videosu için Yotube  Linki:https://youtu.be/E85rLLTprBA
