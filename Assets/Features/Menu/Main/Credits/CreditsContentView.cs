using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.Menu.Main.Credits
{
    /// <summary>
    /// Fills the credits scroll body with sectioned attributions and opens links on click.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class CreditsContentView : MonoBehaviour, IPointerClickHandler
    {
        private const string Accent = "#00E5FF";
        private const string Muted = "#B9B3C9";

        private TextMeshProUGUI _body;

        //===== Lifecycle =====

        private void Awake()
        {
            _body = GetComponent<TextMeshProUGUI>();
            _body.richText = true;
            _body.text = BuildCredits();
            _body.ForceMeshUpdate();
        }

        //===== Event Handlers =====

        public void OnPointerClick(PointerEventData eventData)
        {
            var camera = eventData.pressEventCamera;
            var linkIndex = TMP_TextUtilities.FindIntersectingLink(_body, eventData.position, camera);
            if (linkIndex == -1) return;

            var url = _body.textInfo.linkInfo[linkIndex].GetLinkID();
            if (!string.IsNullOrEmpty(url)) Application.OpenURL(url);
        }

        //===== Utilities =====

        private static string BuildCredits()
        {
            var sb = new StringBuilder(2048);

            AppendSection(sb, "DEVELOPER");
            AppendEntry(
                sb,
                "Game Design & Development",
                Link("https://github.com/bitstachio", "Barbod H.") +
                $" <color={Muted}>·</color> " +
                Link("https://github.com/bitstachio", "github.com/bitstachio"));

            AppendSection(sb, "ART & ICONS");
            AppendEntry(
                sb,
                "Shield Symbol",
                "sbed" +
                $" <color={Muted}>·</color> " +
                Link("https://game-icons.net/1x1/sbed/shield.html", "game-icons.net"));
            AppendEntry(
                sb,
                "Blasts",
                "ansimuz" +
                $" <color={Muted}>·</color> " +
                Link("https://ansimuz.itch.io/warped-shooting-fx", "Warped Shooting FX"));
            AppendEntry(
                sb,
                "Keyboard Keys",
                "Gerald Burke" +
                $" <color={Muted}>·</color> " +
                Link("https://gerald-burke.itch.io/geralds-keys", "Gerald's Keys"));
            AppendEntry(
                sb,
                "Gun Icons",
                "Free Game Assets" +
                $" <color={Muted}>·</color> " +
                Link(
                    "https://free-game-assets.itch.io/free-guns-icon-3232-pixel-pack",
                    "Free Guns Icon Pack"));
            AppendEntry(
                sb,
                "Engine Icon",
                "Magnific" +
                $" <color={Muted}>·</color> " +
                Link("https://www.flaticon.com/free-icons/engine", "Flaticon"));
            AppendEntry(
                sb,
                "Mission Icon",
                "Magnific" +
                $" <color={Muted}>·</color> " +
                Link("https://www.flaticon.com/free-icons/mission", "Flaticon"));

            AppendSection(sb, "AUDIO");
            AppendPixabaySound(sb, "Click", "Matthew Vakalyuk",
                "https://pixabay.com/users/matthewvakaliuk73627-48347364/");
            AppendPixabaySound(sb, "Upgrade Panel Opened", "floraphonic",
                "https://pixabay.com/users/floraphonic-38928062/");
            AppendPixabaySound(sb, "Tap", "freesound_community",
                "https://pixabay.com/users/freesound_community-46691455/");
            AppendPixabaySound(sb, "Blaster", "freesound_community",
                "https://pixabay.com/users/freesound_community-46691455/");
            AppendPixabaySound(sb, "Game Over", "freesound_community",
                "https://pixabay.com/users/freesound_community-46691455/");
            AppendPixabaySound(sb, "Shield Activation", "floraphonic",
                "https://pixabay.com/users/floraphonic-38928062/");
            AppendEntry(
                sb,
                "Laser Beam",
                "Mixkit" +
                $" <color={Muted}>·</color> " +
                Link("https://mixkit.co/free-sound-effects/discover/beam/", "Beam SFX"));
            AppendPixabaySound(sb, "Background Music", "Monume",
                "https://pixabay.com/users/monume-44679891/", isMusic: true);

            AppendSection(sb, "AI-GENERATED");
            AppendEntry(
                sb,
                "Turret, Ground & Posters",
                "Generated with ChatGPT");

            sb.AppendLine();
            AppendLine(sb, $"<color={Muted}><i>Thanks to every creator whose work helped build Entropy.</i></color>");

            return sb.ToString().TrimEnd();
        }

        private static void AppendSection(StringBuilder sb, string title)
        {
            if (sb.Length > 0) sb.AppendLine().AppendLine();
            AppendLine(sb, $"<size=30><color={Accent}>{title}</color></size>");
            AppendLine(sb, $"<color={Accent}>────────────────────────</color>");
        }

        private static void AppendPixabaySound(
            StringBuilder sb,
            string item,
            string author,
            string authorUrl,
            bool isMusic = false)
        {
            var kind = isMusic ? "Music by" : "Sound Effect by";
            AppendEntry(
                sb,
                item,
                $"<color={Muted}>{kind}</color> " +
                Link(authorUrl, author) +
                $" <color={Muted}>from</color> " +
                Link("https://pixabay.com/", "Pixabay"));
        }

        private static void AppendEntry(StringBuilder sb, string item, string creditLine)
        {
            AppendLine(sb, $"<color={Accent}>{item}</color>");
            AppendLine(sb, creditLine);
            sb.AppendLine();
        }

        private static string Link(string url, string label) =>
            $"<link=\"{url}\"><color={Accent}><u>{label}</u></color></link>";

        private static void AppendLine(StringBuilder sb, string line) => sb.AppendLine(line);
    }
}
