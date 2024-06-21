using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMenagement_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, "Buzaçtutuk Öztonga", "Customer Factors Analyst" },
                    { 2, "Akdoğan Baykam", "Dynamic Intranet Strategist" },
                    { 3, "Atıla Koç", "Principal Quality Manager" },
                    { 4, "Bürküt Sadıklar", "Legacy Web Specialist" },
                    { 5, "Çablı Korol", "Dynamic Applications Designer" },
                    { 6, "Gelincik Pektemek", "Dynamic Web Coordinator" },
                    { 7, "Altmışkara Adıvar", "Principal Markets Executive" },
                    { 8, "Basar Berberoğlu", "Dynamic Intranet Executive" },
                    { 9, "Akbaş Erez", "Global Usability Representative" },
                    { 10, "Bağatur Kumcuoğlu", "Chief Functionality Director" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Rem non bilgiyasayarı exercitationem non aliquam ipsum. Corporis illo sed aperiam sunt. Consectetur dışarı dolorem dolayı çorba un ducimus açılmadan otobüs alias. Bilgiyasayarı aut olduğu bilgisayarı.", "Voluptatum aut nihil illo camisi karşıdakine sit sed rem.", 4 },
                    { 2, "Voluptatem adresini sarmal göze sayfası layıkıyla. Sequi kalemi gülüyorum patlıcan dışarı quia. Aspernatur magni consequuntur ad. Doloremque ekşili architecto gidecekmiş düşünüyor totam magnam.", "İusto quam koyun vitae molestiae yapacakmış kulu.", 6 },
                    { 3, "Ona aut masaya aliquid sokaklarda ki voluptas iusto. Anlamsız mutlu makinesi öyle quia enim iusto beğendim. Corporis nisi eve ve sokaklarda dignissimos yapacakmış.", "Beğendim et nihil ona.", 6 },
                    { 4, "Magni aliquam sequi bundan sit ve quia ışık gitti amet. Consequatur dolayı adresini ötekinden domates eaque sıla. Salladı bahar mi consequuntur aspernatur dolores. Adipisci değirmeni qui magni çıktılar salladı labore. Kapının eos autem cesurca batarya anlamsız kalemi voluptate aliquid. Laudantium consectetur voluptatem autem sıfat ipsum çarpan.", "Dışarı ona sed yazın aliquam çobanın çünkü.", 9 },
                    { 5, "Eve illo aut dicta masanın sed mi quis explicabo. Mi consequatur sit. Dışarı totam sed nihil voluptatem ullam aliquam. Beğendim sayfası accusantium quia sıla. Consequatur voluptatem beatae çakıl eaque sequi sit beğendim masanın.", "İn aut sunt masanın camisi suscipit un.", 5 },
                    { 6, "Kapının ekşili eaque. Sevindi enim filmini nihil gördüm adanaya camisi mutlu kapının koşuyorlar. Quaerat quia iure ducimus değirmeni. Ex laboriosam de ama quia ducimus ve sıla sevindi.", "Dağılımı suscipit et teldeki ki nisi ki.", 5 },
                    { 7, "Magnam fugit labore cezbelendi doğru cesurca batarya vel quia lakin. Dicta iusto çorba sevindi çıktılar. Mutlu beğendim doloremque neque nemo sit. Odio velit et minima çorba corporis filmini ama. Odio dağılımı aut sokaklarda velit sit nostrum koştum modi gazete.", "Odit çorba consequatur duyulmamış hesap.", 1 },
                    { 8, "Patlıcan dağılımı mutlu ipsum şafak tempora corporis masanın esse. Deleniti iusto enim camisi voluptas inventore aut. Quam bahar nemo ipsam. Masanın explicabo ama karşıdakine nisi. Düşünüyor ullam quia. Tempora için alias eaque adanaya.", "Adipisci et ekşili kapının blanditiis dignissimos iusto laudantium lambadaki okuma.", 9 },
                    { 9, "Uzattı inventore odio sevindi iusto kutusu teldeki voluptatum quae odio. Eaque enim kapının. Mi iusto uzattı patlıcan ama şafak nihil nisi. Nisi çıktılar sequi balıkhaneye sit mıknatıslı tempora sit patlıcan consequatur.", "Sed quis qui yazın quasi ışık consequuntur in ki düşünüyor.", 3 },
                    { 10, "Çorba aut dicta dignissimos ut. Deleniti illo alias velit patlıcan gazete. Aut enim gördüm dışarı göze adresini voluptatem molestiae. Autem türemiş filmini.", "Enim qui quae mıknatıslı salladı suscipit quae nesciunt voluptatem.", 9 },
                    { 11, "Beğendim odio koştum patlıcan koyun. Gitti aliquam architecto ut quaerat mıknatıslı consectetur sandalye ötekinden. Gülüyorum mutlu layıkıyla eius çarpan ea. Modi dolorem esse doğru sit ea gülüyorum quia olduğu deleniti. Aliquid sıfat gördüm consequatur fugit gidecekmiş veniam explicabo veritatis öyle. Salladı velit adanaya sit modi kulu magni koyun orta değirmeni.", "Cesurca sed düşünüyor bilgiyasayarı olduğu cesurca quam consequatur.", 5 },
                    { 12, "Suscipit et molestiae nesciunt okuma exercitationem alias layıkıyla. Aspernatur ad sit esse. Sarmal voluptatem et sed doğru consequatur dolorem karşıdakine. Ve ut molestiae aliquid şafak sevindi sequi camisi. Consequatur ki et deleniti. Beğendim ut ki numquam.", "Vitae ötekinden düşünüyor.", 8 },
                    { 13, "Enim bundan iusto masaya sequi commodi ut autem yaptı. Değirmeni quis nesciunt eaque voluptatem gazete corporis praesentium açılmadan aspernatur. Sit autem cezbelendi qui enim commodi. Sevindi nemo inventore yaptı eum voluptatem.", "Corporis laboriosam beatae sokaklarda mutlu filmini.", 3 },
                    { 14, "Sit mıknatıslı sevindi lambadaki beğendim cesurca dolor veniam domates. Sunt minima gitti consequatur deleniti balıkhaneye amet aut bahar adipisci. Voluptatem ışık in consequatur consectetur quis yapacakmış umut ea layıkıyla. Et değirmeni quam aut ekşili bilgisayarı consequatur masanın. Olduğu uzattı türemiş gördüm aliquam patlıcan sıla sokaklarda.", "İllo öyle otobüs sokaklarda accusantium voluptatem ötekinden dışarı.", 2 },
                    { 15, "Numquam quasi beatae quis göze çünkü. Domates gördüm eos çobanın dergi odio autem düşünüyor nihil aliquam. İpsum ipsum çobanın molestiae. Neque ea beatae.", "Voluptatem veniam rem autem gülüyorum umut sayfası sıfat quia.", 2 },
                    { 16, "Sandalye modi laudantium çıktılar non ipsa değirmeni deleniti fugit de. Gördüm anlamsız aliquid gidecekmiş ut bahar qui. İncidunt ea telefonu odio okuma ut kulu voluptatem sequi consequatur. Çorba alias dolorem non beğendim ama ducimus.", "Aperiam ex ad minima amet balıkhaneye bahar aliquid enim sıfat.", 10 },
                    { 17, "Ex balıkhaneye nostrum anlamsız ona ut. Kulu mutlu autem şafak sunt rem praesentium çobanın. Kulu illo ut ullam quasi ducimus dicta. Ut velit voluptatem tv. Nesciunt ipsam aspernatur exercitationem.", "Şafak quae lambadaki beğendim mutlu duyulmamış magni et voluptatem orta.", 2 },
                    { 18, "Qui vitae teldeki ratione koyun koyun lambadaki. Gazete mıknatıslı ve. İn reprehenderit exercitationem odit türemiş eos ki quia gitti tempora. Ex ad sit.", "İçin ea quia orta adipisci.", 7 },
                    { 19, "Laudantium kapının masaya öyle sokaklarda sinema eve. Batarya çarpan ab oldular in eve bahar balıkhaneye türemiş. Perferendis vitae quia düşünüyor qui.", "Velit tempora layıkıyla.", 5 },
                    { 20, "Commodi filmini uzattı esse dicta exercitationem düşünüyor çakıl. Quis quis esse aut odit. Ea aut dağılımı sed ötekinden kapının totam. Ex vitae consequatur architecto qui duyulmamış ullam explicabo.", "Aliquid architecto tempora masanın.", 8 },
                    { 21, "Consequatur veritatis alias ea ut rem dignissimos accusantium. Telefonu hesap vel kalemi quasi ötekinden. Çarpan vitae consequatur.", "Sed ipsum sandalye quasi balıkhaneye autem sunt ex çıktılar.", 5 },
                    { 22, "Kulu ki quasi de. Praesentium totam tv doğru sequi batarya sandalye suscipit yazın. Veniam yapacakmış ad iure. İusto exercitationem sıfat.", "Salladı sokaklarda quis esse sevindi.", 4 },
                    { 23, "Dolor ut çobanın oldular eaque cezbelendi çünkü. Vitae koyun layıkıyla neque koyun aut. Koşuyorlar voluptatem cesurca qui gördüm hesap mutlu sıfat. Laboriosam bilgiyasayarı voluptatem sokaklarda neque çorba dolor. Dolorem sed quia olduğu dignissimos qui. Teldeki numquam perferendis sit consequuntur.", "Velit oldular voluptatem uzattı aut.", 7 },
                    { 24, "Bahar explicabo illo ona yaptı. Nemo cesurca tempora sit deleniti sed esse aspernatur türemiş ea. Quasi accusantium commodi.", "Ducimus ad masaya gül deleniti gülüyorum qui voluptas.", 9 },
                    { 25, "Ab makinesi non kalemi açılmadan doğru labore enim amet. Vel anlamsız consectetur. Nisi alias ipsam teldeki nihil. Beğendim sinema alias labore sed balıkhaneye.", "Quis çorba çarpan mi ki beatae cezbelendi dolorem.", 1 },
                    { 26, "Dolores consequatur eum veritatis. İpsam labore çıktılar. Quia laboriosam illo blanditiis bilgiyasayarı quia dolore layıkıyla tempora.", "Enim yapacakmış kutusu çünkü kutusu.", 1 },
                    { 27, "Açılmadan voluptate voluptatem aliquid eaque değerli koştum sed esse odit. Nesciunt nesciunt olduğu velit qui ut voluptas salladı değerli. Beatae gül yaptı. İncidunt rem ut qui.", "Kutusu vel qui et camisi laudantium.", 2 },
                    { 28, "Ea blanditiis gitti. Et aliquid adresini nisi çünkü bilgiyasayarı camisi vel koşuyorlar. Türemiş laboriosam commodi voluptas alias numquam nostrum çobanın quasi quia. İçin enim ve commodi sayfası voluptatem reprehenderit ea nemo. Adanaya telefonu dolore aut. Enim consequatur voluptate ab laboriosam ona bilgiyasayarı.", "Otobüs sıradanlıktan minima enim ea doğru.", 2 },
                    { 29, "Koşuyorlar aliquam layıkıyla bahar filmini. Gül batarya laudantium ad açılmadan ekşili. Layıkıyla labore de. Ki göze quam molestiae ea karşıdakine tv ut aperiam. Fugit otobüs molestiae gazete quis mutlu aut aspernatur sit eius.", "Quam et anlamsız.", 6 },
                    { 30, "Blanditiis gitti ipsam ullam neque kulu. Architecto ama fugit aspernatur ipsa. Umut anlamsız sarmal voluptatem laboriosam consequatur vel. Alias dağılımı layıkıyla umut inventore. Tv bilgisayarı velit batarya dağılımı. İçin öyle suscipit aut.", "Ekşili ama fugit eum çakıl değerli consectetur eve.", 10 },
                    { 31, "Minima eaque suscipit ipsam vel karşıdakine quasi quis yaptı. Çobanın rem okuma doloremque ab sarmal balıkhaneye kapının. Odio karşıdakine sit neque ki sıla. Hesap ekşili sevindi okuma sıradanlıktan eos consequatur çorba.", "Sevindi ışık nihil ona telefonu ki velit in.", 3 },
                    { 32, "Sed dağılımı velit consequatur nostrum. Enim hesap ab vitae ipsum molestiae ex. Aut ışık vel kulu amet salladı sandalye veritatis.", "Kulu ama yapacakmış ea eos ducimus.", 2 },
                    { 33, "Kapının göze dolorem kulu explicabo doğru. Consequatur sarmal consequuntur illo teldeki gitti makinesi beatae. Fugit sit ut değirmeni tv.", "Lakin çünkü anlamsız ea.", 3 },
                    { 34, "Quia iure dağılımı doğru lakin sarmal mıknatıslı ab. Odit aperiam telefonu qui. Sunt sevindi sıradanlıktan. Magni ut ipsa ötekinden orta bilgisayarı sit otobüs odio.", "Sokaklarda laudantium orta değerli exercitationem.", 5 },
                    { 35, "Ex gül sokaklarda de mi yazın veritatis. Explicabo gülüyorum duyulmamış ışık quia. Dolor sayfası kutusu şafak bilgiyasayarı çıktılar suscipit cezbelendi dicta.", "Eaque qui dignissimos qui quia.", 1 },
                    { 36, "Molestiae koyun sinema. Consequatur corporis ama consequatur exercitationem ab aut voluptatem. Voluptate qui nisi quia minima lakin voluptatem enim. Sed explicabo anlamsız tempora göze odio commodi qui patlıcan.", "Enim öyle dolor adipisci architecto kalemi.", 7 },
                    { 37, "Aliquam sequi corporis mutlu filmini velit layıkıyla ona. Eum veritatis voluptatem umut minima bilgiyasayarı voluptatem gidecekmiş. Sed ad voluptatem quaerat. Voluptatem masaya çorba aperiam ut voluptatem odit.", "Çakıl dolor sıradanlıktan.", 3 },
                    { 38, "Quaerat doğru sit enim voluptatum koyun. Bilgisayarı architecto eve açılmadan kutusu eum. Dolore aut anlamsız deleniti yazın makinesi. Quis lakin koşuyorlar voluptatem de. Sinema okuma masanın aliquam ipsum sokaklarda enim.", "Ab quam tv aut.", 5 },
                    { 39, "Sed minima voluptatem nihil iure un quae. Ki consequatur quia ışık türemiş. Aliquam için quaerat uzattı veritatis enim bilgisayarı teldeki layıkıyla. Biber cezbelendi göze.", "Sandalye ea ut kutusu değirmeni iusto quia ışık.", 9 },
                    { 40, "Ut uzattı eve incidunt de exercitationem velit vitae ex. Odit in consequatur. Çıktılar biber incidunt numquam odit magni velit şafak amet ut. Qui orta quaerat quia ex domates layıkıyla ötekinden vel.", "Dolayı ışık qui ullam ut.", 3 },
                    { 41, "Dışarı qui beğendim düşünüyor. Batarya dignissimos çarpan otobüs dergi. Batarya bundan labore dicta nihil vitae labore quam reprehenderit. Quia öyle quasi. Quia laboriosam masanın ea umut sandalye batarya.", "İçin enim ratione biber şafak.", 2 },
                    { 42, "Non eos balıkhaneye ekşili illo eius ut. Fugit quis yazın sunt aperiam sit çıktılar explicabo. Voluptas consequatur dolore beğendim ipsam beğendim. Laudantium numquam salladı. Yapacakmış düşünüyor ipsa yaptı.", "Perferendis değerli düşünüyor ekşili.", 1 },
                    { 43, "Lakin fugit anlamsız masaya voluptatem eius voluptatem gülüyorum in. Voluptatem sandalye qui sevindi vel eve sayfası. Quia ipsum nesciunt dolayı. Uzattı tempora et için. Enim koşuyorlar quasi ipsam deleniti quam. Dağılımı okuma telefonu dağılımı.", "Bilgiyasayarı adresini sayfası dignissimos telefonu.", 10 },
                    { 44, "Deleniti minima dışarı dağılımı. Enim düşünüyor amet sandalye. Fugit tv bilgiyasayarı consectetur. Voluptatem sandalye değirmeni.", "Karşıdakine kulu voluptatem autem çünkü camisi masanın.", 1 },
                    { 45, "Aut blanditiis olduğu amet koşuyorlar enim qui veniam. Kapının ullam quia labore deleniti ama aut voluptatum non. Orta quis un layıkıyla sed kutusu modi enim. Çorba voluptatem veniam için lambadaki. Quis qui ea sunt ama mutlu çıktılar quasi.", "Odio sandalye ducimus voluptas bilgisayarı bahar değirmeni hesap.", 3 },
                    { 46, "Ea bahar autem düşünüyor accusantium dicta. Koştum magni gülüyorum sed velit eaque bilgisayarı ışık ipsam sit. Biber uzattı commodi göze ut ötekinden. Autem çobanın nisi qui non sinema bahar inventore et. Kapının magnam accusantium çünkü quis ötekinden qui nihil biber.", "Ea okuma fugit qui kalemi eaque bundan beğendim.", 2 },
                    { 47, "Yazın ışık aut qui adipisci quae ratione magni ama olduğu. Ea numquam çakıl gördüm minima. Quis yazın cezbelendi gazete. Deleniti qui sinema aperiam çarpan neque. Dolores otobüs yaptı. Mutlu kapının duyulmamış masanın dışarı sed sıla ea doloremque.", "Voluptas quasi aliquam dolores.", 5 },
                    { 48, "Consequatur et sit qui quia. Velit sıfat kutusu koşuyorlar. Vitae voluptas gülüyorum in salladı kulu ipsam autem ratione bilgisayarı.", "Numquam tv fugit praesentium tv.", 2 },
                    { 49, "Sıla aliquid lakin et adipisci. Accusantium qui ipsa. Autem molestiae neque eve ullam qui ışık gördüm de layıkıyla.", "Hesap reprehenderit et et karşıdakine sıfat in ona qui.", 3 },
                    { 50, "Vitae quae quis salladı commodi. Adanaya voluptas adanaya masanın modi aliquid layıkıyla dignissimos. Sit ama makinesi quia olduğu. Aspernatur otobüs aut ekşili ea gülüyorum. Sunt doğru qui bilgiyasayarı tv illo adresini sokaklarda aperiam dolore. Magni tv hesap.", "Sed mutlu ut aliquam illo voluptatem masaya ona.", 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Voluptatum aut nihil illo camisi karşıdakine sit sed rem.", 14, 0 },
                    { 2, "Rem non bilgiyasayarı exercitationem non aliquam ipsum.", 16, 0 },
                    { 3, "İllo sed aperiam sunt eum consectetur dışarı dolorem dolayı.", 9, 0 },
                    { 4, "Ducimus açılmadan otobüs.", 23, 0 },
                    { 5, "Bilgiyasayarı aut olduğu bilgisayarı.", 18, 0 },
                    { 6, "İusto quam koyun vitae molestiae yapacakmış kulu.", 16, 0 },
                    { 7, "Voluptatem adresini sarmal göze sayfası layıkıyla.", 20, 0 },
                    { 8, "Kalemi gülüyorum patlıcan dışarı quia koşuyorlar aspernatur.", 30, 0 },
                    { 9, "Ad aut doloremque ekşili architecto gidecekmiş düşünüyor.", 50, 0 },
                    { 10, "Explicabo kutusu beğendim et nihil ona çünkü voluptatem.", 14, 0 },
                    { 11, "Masaya aliquid sokaklarda ki voluptas iusto incidunt.", 3, 0 },
                    { 12, "Makinesi öyle quia enim iusto.", 18, 0 },
                    { 13, "Corporis nisi eve ve sokaklarda dignissimos yapacakmış.", 30, 0 },
                    { 14, "Dışarı ona sed yazın aliquam çobanın çünkü.", 49, 0 },
                    { 15, "Magni aliquam sequi bundan sit ve quia ışık gitti amet.", 31, 0 },
                    { 16, "Dolayı adresini ötekinden domates eaque sıla eaque salladı bahar.", 3, 0 },
                    { 17, "Aspernatur dolores sequi adipisci değirmeni qui magni.", 11, 0 },
                    { 18, "Labore enim kapının.", 31, 0 },
                    { 19, "Cesurca batarya anlamsız kalemi voluptate aliquid eos laudantium consectetur voluptatem.", 44, 0 },
                    { 20, "İpsum çarpan iure sed in.", 29, 0 },
                    { 21, "Masanın camisi suscipit un sunt exercitationem eve.", 26, 0 },
                    { 22, "Dicta masanın sed mi quis explicabo.", 7, 0 },
                    { 23, "Consequatur sit inventore.", 10, 0 },
                    { 24, "Sed nihil voluptatem ullam aliquam hesap beğendim sayfası accusantium quia.", 12, 0 },
                    { 25, "Consequatur voluptatem beatae çakıl eaque sequi sit beğendim masanın.", 22, 0 },
                    { 26, "Dağılımı suscipit et teldeki ki nisi ki.", 13, 0 },
                    { 27, "Kapının ekşili eaque.", 45, 0 },
                    { 28, "Enim filmini nihil gördüm.", 8, 0 },
                    { 29, "Mutlu kapının koşuyorlar.", 17, 0 },
                    { 30, "Quia iure ducimus değirmeni ea ex laboriosam de.", 21, 0 },
                    { 31, "Ducimus ve sıla sevindi voluptatem beğendim odit.", 9, 0 },
                    { 32, "Duyulmamış hesap dolorem et magnam fugit.", 36, 0 },
                    { 33, "Doğru cesurca batarya vel.", 30, 0 },
                    { 34, "Beğendim dicta iusto çorba.", 11, 0 },
                    { 35, "Quae mutlu beğendim doloremque.", 32, 0 },
                    { 36, "Sit eius odio velit et minima çorba corporis filmini.", 21, 0 },
                    { 37, "Odio dağılımı aut sokaklarda velit sit nostrum koştum modi gazete.", 2, 0 },
                    { 38, "Adipisci et ekşili kapının blanditiis dignissimos iusto laudantium lambadaki okuma.", 47, 0 },
                    { 39, "Patlıcan dağılımı mutlu ipsum şafak tempora corporis masanın esse.", 30, 0 },
                    { 40, "İusto enim camisi voluptas inventore aut koştum quam bahar nemo.", 41, 0 },
                    { 41, "Masanın explicabo ama karşıdakine nisi.", 5, 0 },
                    { 42, "Ullam quia türemiş tempora için alias.", 25, 0 },
                    { 43, "Sit deleniti sed quis.", 49, 0 },
                    { 44, "Quasi ışık consequuntur.", 46, 0 },
                    { 45, "Düşünüyor ama velit uzattı.", 26, 0 },
                    { 46, "Sevindi iusto kutusu teldeki voluptatum quae odio salladı eaque enim.", 18, 0 },
                    { 47, "Mi iusto uzattı patlıcan ama şafak nihil nisi.", 47, 0 },
                    { 48, "Çıktılar sequi balıkhaneye sit mıknatıslı tempora sit patlıcan consequatur.", 14, 0 },
                    { 49, "Enim qui quae mıknatıslı salladı suscipit quae nesciunt voluptatem.", 24, 0 },
                    { 50, "Çorba aut dicta dignissimos ut.", 21, 0 },
                    { 51, "İllo alias velit patlıcan gazete voluptatem aut enim gördüm dışarı.", 13, 0 },
                    { 52, "Voluptatem molestiae teldeki autem türemiş filmini.", 44, 0 },
                    { 53, "Cesurca sed düşünüyor bilgiyasayarı olduğu cesurca quam consequatur.", 38, 0 },
                    { 54, "Beğendim odio koştum patlıcan koyun.", 42, 0 },
                    { 55, "Aliquam architecto ut.", 38, 0 },
                    { 56, "Consectetur sandalye ötekinden şafak gülüyorum.", 17, 0 },
                    { 57, "Eius çarpan ea.", 44, 0 },
                    { 58, "Dolorem esse doğru sit ea gülüyorum quia olduğu.", 50, 0 },
                    { 59, "Aliquid sıfat gördüm consequatur fugit gidecekmiş veniam explicabo veritatis öyle.", 49, 0 },
                    { 60, "Velit adanaya sit.", 36, 0 },
                    { 61, "Magni koyun orta değirmeni düşünüyor.", 4, 0 },
                    { 62, "Ötekinden düşünüyor voluptatem ipsum suscipit et molestiae.", 32, 0 },
                    { 63, "Exercitationem alias layıkıyla göze aspernatur.", 38, 0 },
                    { 64, "Esse eius sarmal voluptatem et sed doğru consequatur dolorem.", 11, 0 },
                    { 65, "Ve ut molestiae aliquid şafak sevindi sequi camisi.", 8, 0 },
                    { 66, "Ki et deleniti lakin beğendim ut.", 7, 0 },
                    { 67, "Aliquam consequatur corporis laboriosam beatae sokaklarda mutlu filmini.", 17, 0 },
                    { 68, "Enim bundan iusto masaya sequi commodi ut autem yaptı.", 47, 0 },
                    { 69, "Quis nesciunt eaque.", 31, 0 },
                    { 70, "Corporis praesentium açılmadan aspernatur uzattı.", 42, 0 },
                    { 71, "Cezbelendi qui enim commodi dolayı sevindi nemo inventore yaptı eum.", 41, 0 },
                    { 72, "Ut illo öyle otobüs sokaklarda.", 24, 0 },
                    { 73, "Ötekinden dışarı sit commodi sit mıknatıslı.", 11, 0 },
                    { 74, "Beğendim cesurca dolor veniam.", 22, 0 },
                    { 75, "Sunt minima gitti consequatur deleniti balıkhaneye amet aut bahar adipisci.", 50, 0 },
                    { 76, "Işık in consequatur consectetur quis yapacakmış umut ea layıkıyla.", 34, 0 },
                    { 77, "Değirmeni quam aut ekşili bilgisayarı consequatur masanın.", 36, 0 },
                    { 78, "Uzattı türemiş gördüm.", 37, 0 },
                    { 79, "Sıla sokaklarda adanaya.", 41, 0 },
                    { 80, "Veniam rem autem gülüyorum umut sayfası sıfat quia eaque.", 20, 0 },
                    { 81, "Quasi beatae quis göze çünkü molestiae domates gördüm.", 31, 0 },
                    { 82, "Dergi odio autem.", 22, 0 },
                    { 83, "Aliquam öyle ipsum ipsum çobanın molestiae otobüs neque ea beatae.", 8, 0 },
                    { 84, "Aperiam ex ad minima amet balıkhaneye bahar aliquid enim sıfat.", 25, 0 },
                    { 85, "Sandalye modi laudantium çıktılar non ipsa değirmeni deleniti fugit de.", 29, 0 },
                    { 86, "Anlamsız aliquid gidecekmiş ut.", 22, 0 },
                    { 87, "Ducimus incidunt ea telefonu odio okuma ut kulu voluptatem sequi.", 23, 0 },
                    { 88, "Çorba alias dolorem non beğendim ama ducimus.", 46, 0 },
                    { 89, "Şafak quae lambadaki beğendim mutlu duyulmamış magni et voluptatem orta.", 34, 0 },
                    { 90, "Ex balıkhaneye nostrum anlamsız ona ut.", 34, 0 },
                    { 91, "Mutlu autem şafak sunt rem.", 49, 0 },
                    { 92, "Architecto kulu illo.", 43, 0 },
                    { 93, "Quasi ducimus dicta sevindi ut velit voluptatem tv göze.", 32, 0 },
                    { 94, "Aspernatur exercitationem lambadaki sinema için ea quia orta adipisci.", 15, 0 },
                    { 95, "Qui vitae teldeki ratione koyun koyun lambadaki.", 4, 0 },
                    { 96, "Mıknatıslı ve vel in reprehenderit.", 40, 0 },
                    { 97, "Türemiş eos ki quia gitti tempora camisi.", 43, 0 },
                    { 98, "Sit sit doğru velit tempora layıkıyla çorba ab laudantium.", 18, 0 },
                    { 99, "Öyle sokaklarda sinema.", 13, 0 },
                    { 100, "Batarya çarpan ab oldular in eve bahar balıkhaneye türemiş.", 18, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
