# FastNotes

FastNotes, notlarınızı kolayca yönetmenizi sağlayan bir uygulamadır. Bu proje, kullanıcıların not oluşturmasına, güncellemesine, silmesine ve görüntülemesine olanak tanır. Ayrıca, kullanıcı kimlik doğrulama ve yenileme token işlemlerini de destekler.

## Özellikler

- **Not Yönetimi**: Not oluşturma, güncelleme, silme ve görüntüleme.
- **Kullanıcı Kimlik Doğrulama**: Google ile kimlik doğrulama.
- **Token Yenileme**: Yenileme token'ları oluşturma ve yenileme.

## Proje Yapısı

- **FastNotes.Application**: Uygulama katmanı, iş mantığı ve DTO'ları içerir.
- **FastNotes.Domain**: Domain katmanı, temel varlıkları içerir.
- **FastNotes.Infrastructure**: Altyapı katmanı, veri erişim katmanını içerir.
- **FastNotes.API**: Web API katmanı, HTTP isteklerini işler.

## Kurulum

1. Bu projeyi klonlayın:
   ```bash
   git clone 
   ```

2. Gerekli bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. Veritabanını güncelleyin:
   ```bash
   dotnet ef database update
   ```

4. Uygulamayı çalıştırın:
   ```bash
   dotnet run --project src/webapi/FastNotes.API
   ```
