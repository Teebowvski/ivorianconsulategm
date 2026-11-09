using Ivory_Coast.ViewModels;

namespace Ivory_Coast.Repo
{
    public class NewsRepository : INewsRepository
    {

        private List<HomeViewModel.News> _newsList;

        public NewsRepository()
        {
            InitializeNews();
        }

        public async Task<List<HomeViewModel.News>> GetAllNewsAsync()
        {
            return await Task.FromResult(_newsList.OrderByDescending(n => n.Published).ToList());
        }

        public async Task<List<HomeViewModel.News>> GetNewsByCategoryAsync(string category)
        {
            var news = _newsList.Where(c => c.Category.ToLower() == category.ToLower()).ToList();

            return news;
        }

        public async Task<HomeViewModel.News> GetNewsByIdAsync(Guid id)
        {
            var news = _newsList.ToList().FirstOrDefault(c => c.Id == id);
            if (news == null)
            {
                return null;
            }
            return news;
        }
        private void InitializeNews()
        {
            _newsList = new List<HomeViewModel.News>
            {
new HomeViewModel.News
{
    Id = Guid.Parse("b7e2c941-6d53-4a81-9f20-3c8d5e7a102b"),
    Title = "Côte d’Ivoire Reopens Honorary Consulate in The Gambia",
    Category = "Diplomatic Relations",
    Publication = "Africa-Press",
    Author = "",
    Image = "/Press/Côte d’Ivoire Reopens Honorary Consulate in The Gambia.jpg",
    Published = DateOnly.Parse("May 26, 2022"),
    Content = @"
        <p><strong>BANJUL, 21 MAY 2022</strong> – The Republic of Côte d’Ivoire officially marked the reopening of its Honorary Consulate in the Republic of The Gambia, reaffirming the longstanding ties between the two sister republics and opening new opportunities for diplomatic, economic and cultural cooperation.</p>

        <p>His Excellency Honourable Papa Yusupha Njie was appointed Honorary Consul of the Republic of Côte d’Ivoire in The Gambia in December 2021. The reopening ceremony brought together distinguished dignitaries, government officials, diplomats, international representatives and members of the business community.</p>

        <p>Among those in attendance were His Excellency General Toure Sekou, Ambassador of the Republic of Côte d’Ivoire to Senegal, The Gambia, Guinea-Bissau, Cabo Verde and Mauritania, with residence in Dakar, Senegal; the Honourable Hamat N.K. Bah, Minister of Tourism and Culture; and Honourable Billay G. Tunkara, Majority Leader and National Assembly Member for Kantora.</p>

        <p>The ceremony was also attended by senior government officials, Her Excellency Madam Vabah K. Gayflor, Resident Representative of the President of the ECOWAS Commission in The Gambia, honorary consuls representing various countries, members of the diplomatic corps, international organisations, the business community, family and friends.</p>

        <h3>Strengthening Bilateral Relations and Economic Diplomacy</h3>

        <p>In his address, Honourable Papa Yusupha Njie described the reopening of the Consulate as more than an initiative to represent and safeguard the interests of the Ivorian community in The Gambia. He emphasised that it would also serve as an important platform for strengthening diplomatic relations and advancing cooperation between the two countries.</p>

        <p>Highlighting Côte d’Ivoire's position as one of West Africa's largest economies and a major economic force on the African continent, the Honorary Consul noted that The Gambia stood to benefit significantly from stronger bilateral economic cooperation.</p>

        <blockquote>
            <p>“My main focus for the next twelve months and during my tenure is to use the Consulate to promote economic diplomacy, paving the way for investors in both countries to increase intra-African trade with each other and other ECOWAS Member States.”</p>
            <footer>– H.E. Honourable Papa Yusupha Njie, Honorary Consul</footer>
        </blockquote>

        <p>He further highlighted the importance of leveraging opportunities under the African Continental Free Trade Area (AfCFTA) and the ECOWAS Trade Liberalisation Scheme (ETLS), which provide access to a regional market of more than 300 million people.</p>

        <p>He expressed his ambition to facilitate investment, promote trade, create employment opportunities, encourage skills and knowledge transfer, and generate sustainable economic benefits for communities in both countries.</p>

        <h3>Government Support and People-to-People Cooperation</h3>

        <p>Mr. Sulayman Omar Njie, Permanent Secretary at the Ministry of Foreign Affairs, International Cooperation and Gambians Abroad, also addressed the gathering, offering words of encouragement and motivation to the newly appointed Honorary Consul.</p>

        <p>The Permanent Secretary urged His Excellency Njie to strengthen people-to-people cooperation between Côte d’Ivoire and The Gambia, particularly in view of the significant Ivorian community residing in The Gambia.</p>

        <p>His remarks underscored the importance of diplomatic representation in fostering stronger cultural, social and economic connections between the citizens of both countries.</p>

        <h3>Tribute to the Late Honorary Consul</h3>

        <p>A minute of silence was observed in honour of the late Alhagi O.B. Conateh, former Honorary Consul of the Republic of Côte d’Ivoire in The Gambia.</p>

        <p>He was remembered and recognised for his outstanding contributions, dedication and services to the people of the Republic of Côte d’Ivoire during his tenure.</p>

        <h3>Appreciation to Both Governments</h3>

        <p>H.E. Honourable Papa Yusupha Njie expressed his sincere gratitude and appreciation to His Excellency Adama Barrow, President of the Republic of The Gambia, for his support and acceptance of the nomination from the Republic of Côte d’Ivoire.</p>

        <p>He also acknowledged the support of the Minister of Foreign Affairs and the Ministry's staff throughout the appointment process.</p>

        <p>Additionally, he extended his appreciation to His Excellency Alassane Ouattara, President of the Republic of Côte d’Ivoire, and His Excellency General Toure Sekou, Ambassador of Côte d’Ivoire to The Gambia and other accredited countries, for the trust and confidence placed in him through his nomination and appointment as Honorary Consul.</p>

        <h3>A New Chapter in Côte d’Ivoire–The Gambia Relations</h3>

        <p>The reopening of the Honorary Consulate marked an important milestone in diplomatic relations between Côte d’Ivoire and The Gambia. It established a renewed platform for consular representation, economic diplomacy, investment promotion and stronger people-to-people engagement.</p>

        <p>Through its renewed presence in Banjul, the Honorary Consulate aims to contribute to deeper regional integration and mutually beneficial partnerships between the two countries and the wider ECOWAS community.</p>
    "
},
               new HomeViewModel.News
{
    Id = Guid.Parse("c8f3d052-7e64-4b92-a130-5d9e6f8b214c"),
    Title = "Ivorian Consulate Donates Vital Supplies to Mile 2 Central Prison",
    Category = "Humanitarian Initiatives",
    Publication = "The Point Newspaper",
    Author = "The Point Newspaper",
    Image = "/Press/Ivorian Consulate Donates Vital Supplies to Mile 2 Central Prison.jpg",
    Published = DateOnly.Parse("Oct 24, 2024"),
    Content = @"
        <p><strong>BANJUL, 24 OCTOBER 2024</strong> – The Honorary Consulate of the Republic of Côte d’Ivoire in The Gambia has donated essential food items and hygiene supplies to Mile 2 Central Prison as part of activities commemorating the 64th Independence Anniversary of the Republic of Côte d’Ivoire.</p>

        <figure>
            <img src='https://thepoint.gm/assets/Featured-Articles/CONSULATE-PHOTO-1__ScaleMaxWidthWzE0MDBd.jpg' alt='Ivorian Consulate officials presenting donated supplies to the Gambia Prison Service at Mile 2 Central Prison' class='img-fluid rounded' />
            <figcaption>Ivorian Consulate officials making a donation to the Gambia Prison Service at Mile 2 Central Prison, marking the 64th Independence Anniversary of the Republic of Côte d’Ivoire.</figcaption>
        </figure>

        <p>The donation was formally handed over during a visit by representatives of the Consulate to the prison facility. The initiative reflects the Consulate's commitment to humanitarian service, community support and strengthening the friendly relations between Côte d’Ivoire and The Gambia.</p>

        <p>The donated supplies included food products and essential hygiene materials intended to support the welfare and daily needs of inmates.</p>

        <h3>Promoting Human Dignity and Solidarity</h3>

        <p>Speaking during the visit, representatives of the Ivorian Consulate highlighted the importance of humanitarian assistance in promoting goodwill, solidarity and stronger cooperation between nations.</p>

        <blockquote>
            <p>“We believe that supporting the well-being of inmates contributes to societal progress. This donation represents our commitment to stand by The Gambia Government in its efforts to reform its prison system. This donation is a symbolic gesture aimed at affirming our commitment to human dignity and promoting the spirit of solidarity during this important day of independence for the Republic of Côte d’Ivoire.”</p>
            <footer>– H.E. Papa Yusupha Njie, Honorary Consul of Côte d’Ivoire in The Gambia</footer>
        </blockquote>

        <h3>Strengthening Cooperation with the Gambia Prison Service</h3>

        <figure>
            <img src='https://thepoint.gm/assets/CONSULATE-PHOTO-2__ResizedImageWzYwMCw0NTBd.jpg' alt='Ivorian Consulate representatives meeting with Gambia Prison Service officials' class='img-fluid rounded' />
            <figcaption>Ivorian Consulate officials and Gambia Prison Service representatives discussing pertinent matters ahead of the donation ceremony.</figcaption>
        </figure>

        <p>The representative of the Director General of the Gambia Prison Service expressed appreciation for the Consulate's generosity and assured the delegation that the donated items would be used for their intended purpose.</p>

        <p>The representative also prayed for continued blessings upon the Republic of Côte d’Ivoire and encouraged the Consulate to sustain its humanitarian contributions to the Gambian community. The inmates would also be informed of the gesture and encouraged to remember the Consulate in their prayers.</p>

        <p>The initiative was described as an important contribution towards building a brighter future for inmates and supporting efforts to improve their welfare and living conditions.</p>

        <h3>Items Donated</h3>

        <p>The donation comprised a range of food, household and hygiene supplies, including:</p>

        <ul>
            <li>Bags of rice and bags of sugar</li>
            <li>Tea bags and powdered milk</li>
            <li>Cooking oil, tomato paste and butter</li>
            <li>Bottles of pepper and other condiments</li>
            <li>Liquid soap and bleach</li>
            <li>Plastic kettles and water jugs</li>
            <li>Plastic cups and plates</li>
            <li>Plastic hand fans and sleeping mats</li>
        </ul>

        <h3>Continued Commitment to Community Development</h3>

        <p>The donation is expected to contribute to ongoing efforts to improve living conditions at Mile 2 Central Prison while supporting broader prison welfare and reform initiatives in The Gambia.</p>

        <p>The Honorary Consulate also reaffirmed its commitment to supporting other community programmes and humanitarian initiatives across the country, reflecting its broader mission of promoting friendship, cooperation and solidarity between the peoples of Côte d’Ivoire and The Gambia.</p>

        <h3>Contact Information</h3>

        <p>For media inquiries and further information, please contact:</p>

        <p><strong>Honorary Consulate of the Republic of Côte d’Ivoire in The Gambia</strong></p>

        <ul>
            <li><strong>Telephone:</strong> +220 3427777</li>
            <li><strong>Email:</strong> <a href='mailto:info@ivorianconsulategm.org'>info@ivorianconsulategm.org</a></li>
        </ul>
    "
},
              new HomeViewModel.News
{
    Id = Guid.Parse("d9a4e163-8f25-4c73-b612-7e0f9a5c321b"),
    Title = "President Barrow Receives Côte d’Ivoire’s Ambassador to The Gambia",
    Category = "Diplomatic Relations",
    Publication = "Office of the President, Republic of The Gambia",
    Author = "Office of the President",
    Image = "/Gallery/images/WhatsApp Image 2026-11-03 at 8.32.44 PM.jpeg",
    Published = DateOnly.Parse("Sep 13, 2025"),
    Content = @"
        <p><strong>STATE HOUSE, BANJUL, 12 SEPTEMBER 2025</strong> – His Excellency President Adama Barrow received the letters of credence of the newly accredited Ambassador of the Republic of Côte d’Ivoire to The Gambia, His Excellency Mamadou Haïdara, during a diplomatic ceremony at State House in Banjul.</p>
 

        <p>During the presentation, Ambassador Haïdara conveyed the warm greetings of His Excellency President Alassane Ouattara of the Republic of Côte d’Ivoire and extended his wishes for President Barrow's prayers for lasting peace and stability across the sub-region.</p>

        <p>The Ambassador reaffirmed Côte d’Ivoire's commitment to strengthening its longstanding relationship with The Gambia, highlighting opportunities for enhanced bilateral cooperation in areas of mutual interest.</p>

        <h3>Strengthening Energy Cooperation</h3>

        <p>A key highlight of the diplomatic engagement was Ambassador Haïdara's announcement that Côte d’Ivoire had accepted an energy-sharing partnership with The Gambia. The proposed cooperation represents an important step towards strengthening regional energy collaboration and supporting The Gambia's development ambitions.</p>

        <p>President Barrow welcomed the announcement and expressed appreciation for Côte d’Ivoire's commitment to energy cooperation, emphasising the importance of reliable and affordable electricity for economic growth and industrial development.</p>

        <blockquote>
            <p>“Energy used to be a privilege. Now it is a right. One cannot industrialise without reliable and affordable electricity.”</p>
            <footer>– H.E. President Adama Barrow, President of the Republic of The Gambia</footer>
        </blockquote>

        <p>The President also recognised the strong and friendly relations between the two countries, noting that closer energy cooperation would contribute to regional integration and economic progress.</p>

        <h3>Promoting Regional Connectivity and ECOWAS Cooperation</h3>

        <p>President Barrow further encouraged the inclusion of Banjul on the routes of Air Côte d’Ivoire as part of efforts to improve air connectivity within West Africa and facilitate stronger commercial, diplomatic and people-to-people exchanges.</p>

        <p>He emphasised the importance of working together through the Economic Community of West African States (ECOWAS) to address shared regional challenges and advance common development objectives.</p>

        <p>President Barrow also expressed gratitude to President Alassane Ouattara for Côte d’Ivoire's support during The Gambia's democratic transition and for his continued commitment to the principles and ideals of ECOWAS.</p>

        <figure>
            <img src='/Gallery/images/WhatsApp Image 2026-11-03 at 8.32.44 PM (1).jpeg' alt='President Adama Barrow and Ambassador Mamadou Haïdara during the diplomatic engagement at State House' class='img-fluid rounded' />
            <figcaption>President Adama Barrow and representatives of the Republic of Côte d’Ivoire during the diplomatic engagement at State House.</figcaption>
        </figure>

        <h3>A Renewed Commitment to Bilateral Relations</h3>

        <p>The accreditation of Ambassador Mamadou Haïdara reflects the continued commitment of Côte d’Ivoire and The Gambia to strengthening diplomatic relations and expanding cooperation across strategic sectors.</p>

        <p>With energy cooperation, regional connectivity, trade and economic development among the areas of shared interest, the engagement provides renewed momentum for a stronger partnership between the two sister republics.</p>

        <p>The Honorary Consulate of the Republic of Côte d’Ivoire in The Gambia welcomes these developments and remains committed to supporting initiatives that promote friendship, bilateral cooperation, economic diplomacy and stronger ties between the peoples of Côte d’Ivoire and The Gambia.</p>

        <hr />

        <p><strong>Source:</strong> Office of the President, Republic of The Gambia.</p>
        <p><a href='https://www.op.gov.gm/'>www.op.gov.gm</a></p>
    "
}
            };
        }
    }



}
