using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AssemblyCSharp;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class ControlEvent : MonoBehaviour, IEventSystemHandler
{

    public const int NUMBER_FLOOR = 6;

    public Button searchBtn;
    public Button reservedBtn;
    public Button numSearchBtn;
    public Button bathroomSearchBtn;
    public Button segmentSearchBtn;
    public Button resizeVideo;
    public Button exitViedo;
    public RawImage Videocarosel;
    public RawImage VideoDirection;
    public Text showTime;
    public Text floorOfficeOn;
    public Text officePhoneNumber;
    public Text officeShowName;
    public Text officeFliter;
    public Image officeLogo;
    public Canvas evnt1;
    public Canvas evnt2;
    public Canvas evnt3;

    //public GameObject startAnimation;
    public GameObject endAnimation;
    public GameObject printPoint;

    //public GameObject flatStart;

    public Material yellowTarget;

    public GameObject cube;

    public Image floorSelector;
    public Image headerImg;
    public static string currentLanguage = null;

    static public string eventSpriteName = "eventbtn";

    public Color orangeColor = new Color(243 / 255f, 111 / 255f, 33 / 255f);

    string[] nameOfAllResource = new string[]{
        "0","1","2","3","4","5","6","7","8","9",
        "0handi","1handi","2handi","3handi","4handi","5handi","6handi","7handi","8handi","9handi",
        "backspace","backspacehandi","space","spacehandi","textboxbackground","textboxbackgroundhandi",
        "officebackground","officebackgroundhandi",
        "8_1","8_1handi","8_2","8_2handi","8_3","8_3handi","8_4",
        "8_4handi","8_5","8_5handi","8_6","8_6handi",
        "numberfloor1","numberfloor1handi","numberfloor2","numberfloor2handi",
        "numberfloor3","numberfloor3handi","numberfloor4","numberfloor4handi",
        "numberfloor5","numberfloor5handi","numberfloor6","numberfloor6handi",
        "n-130","n-130handi","131-178","131-178handi","n-230","n-230handi","231-265","231-265handi",
        "n-330","n-330handi","331-371","331-371handi","401-406","401-406handi",
        "501-n","501-nhandi","n-q96","n-q96handi",
        "handicap","backgroundevnthandi","backgroundevnt","eventDateBackgroundhandi","eventDateBackground",
        "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
        "Ahandi","Bhandi","Chandi","Dhandi","Ehandi","Fhandi","Ghandi","Hhandi","Ihandi","Jhandi","Khandi","Lhandi","Mhandi","Nhandi",
        "Ohandi","Phandi","Qhandi","Rhandi","Shandi","Thandi","Uhandi","Vhandi","Whandi","Xhandi","Yhandi","Zhandi",
        "atoz","atozhandi","videoFrameBar","videoFrameBarhandi",
        "next","close","closehandi","bathroom","bathroomhandi",
        "nexthandicap","number","numberhandi","officeInfomationBackground","officeInfomationBackgroundhandi",
        "previous","previoushandicap","segment","segmenthandi",
        "selectorletterarrow","selectorletterarrowhandi","selectorblockarrow","selectorblockarrowhandi","selectornumberarrow","selectornumberarrowhandi",
        "selectorsegmentarrow","selectorsegmentarrowhandi","selectorofficearrow","selectorofficearrowhandi",
        "selectorstorearrow","selectorstorearrowhandi","eventbtn","eventbtnhandi","eventbtnsmall","eventbtnsmallhandi",
        "gyms","art","bank","bijou","hair",
        "shoes", "home", "party", "others","electric", "pharma",
        "natural","gastronomy","jewelry","automotive", "libraries",
        "womenfashion","kidfashion","lingerie","menfashion","unisexfashion",
        "optics","petshop","kiosks","telephone",
        "gymshandi","arthandi","bankhandi","bijouhandi","hairhandi",
        "shoeshandi", "homehandi", "partyhandi", "othershandi","electrichandi","pharmahandi",
        "naturalhandi","gastronomyhandi","jewelryhandi","automotivehandi", "librarieshandi",
        "womenfashionhandi","kidfashionhandi","lingeriehandi","menfashionhandi","unisexfashionhandi",
        "opticshandi","petshophandi","kioskshandi","telephonehandi","cinemaButton","cinemaButtonhandi","theaterButton","theaterButtonhandi",
        "scheduleBackground","scheduleBackgroundhandi",

        "brazilhandicap",
        "brazilbackspace","brazilbackspacehandi","brazilspace","brazilspacehandi",
        "brazil8_1","brazil8_1handi","brazil8_2","brazil8_2handi","brazil8_3","brazil8_3handi",
        "brazil8_4","brazil8_4handi","brazil8_5","brazil8_5handi","brazil8_6","brazil8_6handi",
        "brazilnumberfloor1","brazilnumberfloor1handi","brazilnumberfloor2","brazilnumberfloor2handi",
        "brazilnumberfloor3","brazilnumberfloor3handi","brazilnumberfloor4","brazilnumberfloor4handi",
        "brazilnumberfloor5","brazilnumberfloor5handi","brazilnumberfloor6","brazilnumberfloor6handi",
        "brazilatoz","brazilatozhandi","brazilbathroom","brazilbathroomhandi",
        "brazileventbtn","brazileventbtnhandi","brazilevents","brazileventbtnsmall","brazileventbtnsmallhandi",
        "brazilnumber","brazilnumberhandi",
        "brazilsegment","brazilsegmenthandi",
        "brazilselectorletterarrow","brazilselectorletterarrowhandi","brazilselectorblockarrow","brazilselectorblockarrowhandi","brazilselectornumberarrow","brazilselectornumberarrowhandi",
        "brazilselectorsegmentarrow","brazilselectorsegmentarrowhandi","brazilselectorofficearrow","brazilselectorofficearrowhandi",
        "brazilselectorstorearrow","brazilselectorstorearrowhandi",
        "brazilgyms","brazilart","brazilbank","brazilbijou","brazilhair","brazilpharma",
        "brazilshoes", "brazilhome", "brazilparty", "brazilothers","brazilelectric",
        "brazilnatural","brazilgastronomy","braziljewelry","brazilautomotive", "brazillibraries",
        "brazilwomenfashion","brazilkidfashion","brazillingerie","brazilmenfashion","brazilunisexfashion",
        "braziloptics","brazilpetshop","brazilkiosks","braziltelephone",
        "brazilgymshandi","brazilarthandi","brazilbankhandi","brazilbijouhandi","brazilhairhandi",
        "brazilshoeshandi", "brazilhomehandi", "brazilpartyhandi", "brazilothershandi","brazilelectrichandi","brazilpharmahandi",
        "brazilnaturalhandi","brazilgastronomyhandi","braziljewelryhandi","brazilautomotivehandi", "brazillibrarieshandi",
        "brazilwomenfashionhandi","brazilkidfashionhandi","brazillingeriehandi","brazilmenfashionhandi","brazilunisexfashionhandi",
        "brazilopticshandi","brazilpetshophandi","brazilkioskshandi","braziltelephonehandi","brazilcinemaButton","brazilcinemaButtonhandi","braziltheaterButton","braziltheaterButtonhandi",
        "brazilscheduleBackground","brazilscheduleBackgroundhandi",

        "spanishhandicap",
        "spanishbackspace","spanishbackspacehandi","spanishspace","spanishspacehandi",
        "spanish8_1","spanish8_1handi","spanish8_2","spanish8_2handi","spanish8_3","spanish8_3handi",
        "spanish8_4","spanish8_4handi","spanish8_5","spanish8_5handi","spanish8_6","spanish8_6handi",
        "spanishnumberfloor1","spanishnumberfloor1handi","spanishnumberfloor2","spanishnumberfloor2handi",
        "spanishnumberfloor3","spanishnumberfloor3handi","spanishnumberfloor4","spanishnumberfloor4handi",
        "spanishnumberfloor5","spanishnumberfloor5handi","spanishnumberfloor6","spanishnumberfloor6handi",
        "spanishatoz","spanishatozhandi","spanishbathroom","spanishbathroomhandi",
        "spanisheventbtn","spanisheventbtnhandi","spanishevents","spanisheventbtnsmall","spanisheventbtnsmallhandi",
        "spanishnumber","spanishnumberhandi",
        "spanishsegment","spanishsegmenthandi","spanishselectorletterarrow","spanishselectorletterarrowhandi","spanishselectorblockarrow","spanishselectorblockarrowhandi","spanishselectornumberarrow","spanishselectornumberarrowhandi",
        "spanishselectorsegmentarrow","spanishselectorsegmentarrowhandi","spanishselectorofficearrow","spanishselectorofficearrowhandi",
        "spanishselectorstorearrow","spanishselectorstorearrowhandi",
        "spanishgyms","spanishart","spanishbank","spanishbijou","spanishhair",
        "spanishshoes", "spanishhome", "spanishparty", "spanishothers","spanishelectric", "spanishpharma",
        "spanishnatural","spanishgastronomy","spanishjewelry","spanishautomotive", "spanishlibraries",
        "spanishwomenfashion","spanishkidfashion","spanishlingerie","spanishmenfashion","spanishunisexfashion",
        "spanishoptics","spanishpetshop","spanishkiosks","spanishtelephone",
        "spanishgymshandi","spanisharthandi","spanishbankhandi","spanishbijouhandi","spanishhairhandi",
        "spanishshoeshandi", "spanishhomehandi", "spanishpartyhandi", "spanishothershandi","spanishelectrichandi","spanishpharmahandi",
        "spanishnaturalhandi","spanishgastronomyhandi","spanishjewelryhandi","spanishautomotivehandi", "spanishlibrarieshandi",
        "spanishwomenfashionhandi","spanishkidfashionhandi","spanishlingeriehandi","spanishmenfashionhandi","spanishunisexfashionhandi",
        "spanishopticshandi","spanishpetshophandi","spanishkioskshandi","spanishtelephonehandi","spanishcinemaButton","spanishcinemaButtonhandi","spanishtheaterButton","spanishtheaterButtonhandi",
        "spanishscheduleBackground","spanishscheduleBackgroundhandi"

    };
    /*"","","","","","","","","","",
    "","","","","","","","","","",};*/

    string[] segmentNameArray = new string[]{
        "gyms","art","bank","bijou","hair",
        "shoes", "home", "party", "pharma", "electric",
        "natural","gastronomy","jewelry","automotive", "libraries",

        "womenfashion","kidfashion","lingerie","menfashion","unisexfashion",
        "optics","petshop","kiosks","telephone", "others"
    };

    public Button fl1, fl2, fl3, fl4;

    public RawImage containvideoOffice;

    //public MoviePlayer videoOffice;

    float ratetio = 1f;

    private Dictionary<string, Vector3> PositnBlock = new Dictionary<string, Vector3>();

    Vector3 block8_1 = new Vector3(298.96f, 0.2f, 187.54f);
    Vector3 block8_2 = new Vector3(300.06f, 0.2f, 185.28f);
    Vector3 block8_3 = new Vector3(297.31f, 0.2f, 187.78f);
    Vector3 block8_4 = new Vector3(298.42f, 0.2f, 191.4f);
    Vector3 block8_5 = new Vector3(298.4f, 0.2f, 187.5f);
    Vector3 block8_6 = new Vector3(297.9f, 0.2f, 188.1f);


    Vector3 block8_1h = new Vector3(298.96f, 1000f, 187.54f);
    Vector3 block8_2h = new Vector3(300.06f, 1000f, 185.28f);
    Vector3 block8_3h = new Vector3(297.31f, 1000f, 187.78f);
    Vector3 block8_4h = new Vector3(298.42f, 1000f, 191.4f);
    Vector3 block8_5h = new Vector3(298.4f, 1000f, 187.5f);
    Vector3 block8_6h = new Vector3(297.9f, 1000f, 188.1f);

    Vector3 block8_1transparent = new Vector3(298.96f, 1000f, 187.54f);
    Vector3 block8_2transparent = new Vector3(300.06f, 1000f, 185.28f);
    Vector3 block8_3transparent = new Vector3(297.31f, 1000f, 187.78f);
    Vector3 block8_4transparent = new Vector3(298.42f, 1000f, 191.4f);
    Vector3 block8_5transparent = new Vector3(298.4f, 1000f, 187.5f);


    static Vector3 posBlock6 = new Vector3(282.9F, 44.0F, 244.7F);
    static Vector3 lookatBlock6 = new Vector3(287.1F, 10.0F, 205.0F);


    Vector3 routeblock8_2 = new Vector3(300.5f, 35f, 189.3f);

    //Vector3 hideStartPoint = new Vector3 (200f, 1000f, 200f);
    Vector3 hideEndPoint = new Vector3(200f, 1000f, 200f);


    Point8_1 block8_1Info = new Point8_1();
    Point8_2 block8_2Info = new Point8_2();
    Point8_3 block8_3Info = new Point8_3();
    Point8_4 block8_4Info = new Point8_4();
    Point8_5 block8_5Info = new Point8_5();
    Point8_6 block8_6Info = new Point8_6();

    Point8_1handicap block8_1Infohandicap = new Point8_1handicap();
    Point8_2handicap block8_2Infohandicap = new Point8_2handicap();
    Point8_4handicap block8_4Infohandicap = new Point8_4handicap();
    Point8_5handicap block8_5Infohandicap = new Point8_5handicap();
    Point8_6handicap block8_6Infohandicap = new Point8_6handicap();



    Vector3[] listpoint;

    int currentBlock = 8;


    public const string imageType = ".png", videoType = ".avi";
    public GameObject arrow = null;

    public GameObject Cylinder = null;


    public int maxOffice = 18;
    private int currentIndex = 0;


    public bool update = false;

    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.


    private System.Timers.Timer aTimer;
    private System.Timers.Timer carouselTimer;
    private System.Timers.Timer moveNextCamera;
    private System.Timers.Timer showTimeTimer;
    private System.Timers.Timer fullScreenTimer;
    private System.Timers.Timer hideInfomationTimer;
    private System.Timers.Timer closeTimer;

    public string IP = "http://localhost:8080/";


    List<string> TextureBtn =
        new List<string>();
    List<string> nameOffices =
        new List<string>();
    static Vector3 center = new Vector3(291.4F, 6.7F, 205.0F);
    static Vector3 orginalPostion = new Vector3(291.4F, 57.8F, 233.9F);

    int screenWidth = -1;
    int screenHeigh = -1;

    float crsPosx = -1f;
    float crsPosy = -1f;
    //web


    public ShowCrsVideo movieCrsPlayer;

    //height = 768
    //width = 1366
    //pos x = 971
    //pos y = 537

    // Use this for initialization
    void Start()
    {
        //writetofile.append2File (buginfo, "\n---------------START--------------");
        //Screen.SetResolution (2048, 2048, false);
        Screen.fullScreen = true;
        screenWidth = Screen.width;
        screenHeigh = Screen.height;
        crsPosx = Videocarosel.transform.position.x - 192f;
        crsPosy = screenHeigh - Videocarosel.transform.position.y - 109f;
        resetVideoCrs();

        StartCoroutine(loadVideoFromResources());

        StartCoroutine(loadAllResources());

        target = center;

        PositnBlock.Add("block8_1", block8_1);
        PositnBlock.Add("block8_2", block8_2);
        PositnBlock.Add("block8_3", block8_3);
        PositnBlock.Add("block8_4", block8_4);
        PositnBlock.Add("block8_5", block8_5);
        PositnBlock.Add("block8_6", block8_6);


        PositnBlock.Add("block8_1h", block8_1h);
        PositnBlock.Add("block8_2h", block8_2h);
        PositnBlock.Add("block8_3h", block8_3h);
        PositnBlock.Add("block8_4h", block8_4h);
        PositnBlock.Add("block8_5h", block8_5h);
        PositnBlock.Add("block8_6h", block8_6h);

        PositnBlock.Add("block8_1transparenth", block8_1transparent);
        PositnBlock.Add("block8_2transparenth", block8_2transparent);
        PositnBlock.Add("block8_3transparenth", block8_3transparent);
        PositnBlock.Add("block8_4transparenth", block8_4transparent);
        PositnBlock.Add("block8_5transparenth", block8_5transparent);

        PositnBlock.Add("posBlock6", posBlock6);
        PositnBlock.Add("lookatBlock6", lookatBlock6);


        PositnBlock.Add("routeblock8_2", routeblock8_2);


        //blockSelector = blockSelector.GetComponent<Canvas> ();
        fl1 = fl1.GetComponent<Button>();
        fl2 = fl2.GetComponent<Button>();
        fl3 = fl3.GetComponent<Button>();
        //containBlock = containBlock.GetComponent<Canvas> ();
        searchBtn = searchBtn.GetComponent<Button>();
        reservedBtn = reservedBtn.GetComponent<Button>();

        isShowVideo(false);

        showTimeTimer = new System.Timers.Timer(1000);

        showTimeTimer.Elapsed += OnShowTimedEvent;

        showTimeTimer.Start();

        fullScreenTimer = new System.Timers.Timer(60000);

        fullScreenTimer.Elapsed += OnShowFullScreenEvent;

        fullScreenTimer.Start();

        hideInfomationTimer = new System.Timers.Timer(30000);

        hideInfomationTimer.Elapsed += OnShowHideInfoEvent;

        hideInfomationTimer.Stop();

        closeTimer = new System.Timers.Timer(30000);

        closeTimer.Elapsed += OnCloseCinema;

        closeTimer.Stop();

        aTimer = new System.Timers.Timer(30000);

        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;

        aTimer.Start();

        /*
		timerBoom = new System.Timers.Timer(3600000);
		timerBoom.Elapsed += OnTimedBoomEvent;		
		timerBoom.Start ();*/

        moveNextCamera = new System.Timers.Timer(2000);

        // Hook up the Elapsed event for the timer. 
        moveNextCamera.Elapsed += move2NextCamera;

        moveNextCamera.Stop();
        containvideoOffice.enabled = false;
        StartCoroutine(sysServer());
        StartCoroutine(addNewOffice());

        setCamera(orginalPostion, target);

        m_ShowEventParameterId = Animator.StringToHash(k_showEventTransitionName);
        m_showScreenParameterId = Animator.StringToHash(k_showScreenTransitionName);
        m_OpenParameterId = Animator.StringToHash(k_OpenTransitionName);
        m_OpenMovieParameterId = Animator.StringToHash(k_OpenMovieTransitionName);
        m_FullScreenParameterId = Animator.StringToHash(k_FullScreenTransitionName);
        m_showDirctionVideoId = Animator.StringToHash(k_showDirctionVideoTransitionName);
        m_showAnimationButtonPressed = Animator.StringToHash(k_buttonPressTransitionName);
        m_showAnimationBlockPressed = Animator.StringToHash(k_buttonBlockPressTransitionName);
        changeLanguare("brazil");
    }

    public static string fullPathVideoFolder = "C:/server/";

    void resetVideoCrs()
    {
        movieCrsPlayer.setRectVideo(crsPosx, crsPosy, 384, 218);
    }
    void fullScreenVideoCrs()
    {
        movieCrsPlayer.setRectVideo(0, 0, screenWidth, screenHeigh);
    }

    void showCarousel(bool isShow)
    {
        if (!isShow)
            movieCrsPlayer.setRectVideo(screenWidth, screenHeigh, 384, 218);
        else
            resetVideoCrs();
    }

    bool beginmovetonextcamera = false;
    Vector3 lattt, posss, thirdCameraPostion, thirdCameraLookat;
    private void move2NextCamera(object o, System.Timers.ElapsedEventArgs e)
    {
        beginmovetonextcamera = true;
        moveNextCamera.Stop();
    }

    //public ShowCrsVideo playyyyyyyyyyyy;
    public void numberSearchPress()
    {
        resetTimer();
        hideEventAndInfomation();
        exitvideo();
        hideOldeScreen();

        showFullTransparent();

        GameObject.Find("PanelContainblocks").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
        currentNameLayoutShow = "PanelContainblocks";
        //showBlockSelector ();
    }
    /*
	private void hideBlockSelector(){
		
		blockSelector.enabled = false;
		containBlock.enabled = false;
	}
	private void showBlockSelector(){		
		blockSelector.enabled = true;
		containBlock.enabled = true;
	}*/

    string currenNameLayoutMovie;
    public void cinemaPress()
    {
        //writetofile.append2File (buginfo, "\ncinemaPress:");
        resetTimer();
        hideEventAndInfomation();
        exitvideo();
        hideOldeScreen();
        StartCoroutine(showCinema());
        closeTimer.Start();
    }

    private IEnumerator showCinema()
    {
        yield return new WaitForSeconds(0.2F);//for 64bit

        //showFullTransparent ();
        currentCinema = 0;
        int index = 0;
        foreach (string x in infomationCinema)
        {
            if (x != "")
            {
                string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                StartCoroutine(loadTexture4Cinema(info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7], index));
                index++;
            }
        }

        GameObject.Find("PanelcontainCinema").GetComponent<Animator>().SetBool(m_OpenMovieParameterId, true);
        currenNameLayoutMovie = "PanelcontainCinema";
        showCarousel(false);
    }

    public void theaterPress()
    {
        //writetofile.append2File (buginfo, "\ntheaterPress:");
        resetTimer();
        hideEventAndInfomation();
        exitvideo();
        hideOldeScreen();
        StartCoroutine(showTheater());
        closeTimer.Start();
        //showBlockSelector ();
    }

    private IEnumerator showTheater()
    {
        yield return new WaitForSeconds(0.2F);//for 64bit

        //showFullTransparent ();
        currentTheater = 0;
        int index = 0;
        foreach (string x in infomationTheater)
        {
            if (x != "")
            {
                string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                StartCoroutine(loadTexture4Theater(info[0], info[1], info[2], info[3], info[4], info[5], info[6], index));
                index++;
            }
        }

        GameObject.Find("PanelcontainTheater").GetComponent<Animator>().SetBool(m_OpenMovieParameterId, true);
        currenNameLayoutMovie = "PanelcontainTheater";
        showCarousel(false);
    }

    static public Dictionary<string, Sprite> ResourcesDictionary = new Dictionary<string, Sprite>();
    private bool dontAddhandi = false;
    private bool handicap = false;
    private string[] arrayCharacter = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public void handicapMode()
    {
        resetTimer();
        if (!handicap)
        {
            //VideoDirection.texture = movieTextureDirctionElevator;
            searchBtn.image.sprite = ResourcesDictionary[currentLanguage + "atozhandi"];
            bathroomSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "bathroomhandi"];
            if (!dontAddhandi)
            {
                foreach (string cha in arrayCharacter)
                {
                    GameObject.Find(cha).GetComponent<Image>().sprite = ResourcesDictionary[cha + "handi"];
                }
                eventSpriteName += "handi";
            }
            reservedBtn.image.sprite = ResourcesDictionary[currentLanguage + eventSpriteName];
            numSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "numberhandi"];
            segmentSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "segmenthandi"];
            GameObject.Find("containresultoffice").GetComponent<Image>().sprite = ResourcesDictionary["officebackgroundhandi"];
            GameObject.Find("Imagetextboxbackground").GetComponent<Image>().sprite = ResourcesDictionary["textboxbackgroundhandi"];
            GameObject.Find("space").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "spacehandi"];
            GameObject.Find("backspace").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "backspacehandi"];
            for (int i = 0; i < 10; i++)
                GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i + "handi"];
            GameObject.Find("n-130").GetComponent<Image>().sprite = ResourcesDictionary["n-130handi"];
            GameObject.Find("131-178").GetComponent<Image>().sprite = ResourcesDictionary["131-178handi"];
            GameObject.Find("n-230").GetComponent<Image>().sprite = ResourcesDictionary["n-230handi"];
            GameObject.Find("231-265").GetComponent<Image>().sprite = ResourcesDictionary["231-265handi"];
            GameObject.Find("n-330").GetComponent<Image>().sprite = ResourcesDictionary["n-330handi"];
            GameObject.Find("331-371").GetComponent<Image>().sprite = ResourcesDictionary["331-371handi"];
            GameObject.Find("401-406").GetComponent<Image>().sprite = ResourcesDictionary["401-406handi"];
            GameObject.Find("501-n").GetComponent<Image>().sprite = ResourcesDictionary["501-nhandi"];
            GameObject.Find("n-q96").GetComponent<Image>().sprite = ResourcesDictionary["n-q96handi"];
            GameObject.Find("Panelcontainfloor1").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor1handi"];
            GameObject.Find("Panelcontainfloor2").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor2handi"];
            GameObject.Find("Panelcontainfloor3").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor3handi"];
            GameObject.Find("Panelcontainfloor4").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor4handi"];
            GameObject.Find("Panelcontainfloor5").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor5handi"];
            GameObject.Find("Panelcontainfloor6").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor6handi"];
            GameObject.Find("pleaseselectyourletter").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorletterarrowhandi"];
            GameObject.Find("pleaseselectyournumber").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectornumberarrowhandi"];
            GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorofficearrowhandi"];
            GameObject.Find("pleaseselectyoursegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorsegmentarrowhandi"];
            if (currentBlock > 5 && currentBlock < 9)
                floorSelector.sprite = ResourcesDictionary[currentLanguage + currentBlock + "_" + currentFloor + "handi"];
            else floorSelector.sprite = ResourcesDictionary[currentLanguage + "3_" + currentFloor + "handi"];
            GameObject.Find("borderImg").GetComponent<Image>().sprite = ResourcesDictionary["videoFrameBarhandi"];
            GameObject.Find("containBlockInfomation").GetComponent<Image>().sprite = ResourcesDictionary["officeInfomationBackgroundhandi"];
            headerImg.color = new Color(21 / 255f, 61 / 255f, 115 / 255f);
            GameObject.Find("nextEvent").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
            GameObject.Find("nextResult").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
            GameObject.Find("nextSeg").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
            GameObject.Find("previousEvent").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
            GameObject.Find("previousResult").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
            GameObject.Find("previousSeg").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
            GameObject.Find("CloseEvent").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
            GameObject.Find("CloseResult").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
            GameObject.Find("CloseSegment").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
            GameObject.Find("CloseKeyboard").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
            GameObject.Find("CloseNumber").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
            evnt1.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
            evnt2.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
            evnt3.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
            GameObject.Find("Imagetime1").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
            GameObject.Find("Imagetime2").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
            GameObject.Find("Imagetime3").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
            GameObject.Find("cinemaBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "cinemaButtonhandi"];
            GameObject.Find("theaterBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "theaterButtonhandi"];
            GameObject.Find("containCinemaTheater").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "scheduleBackgroundhandi"];
        }
        else
        {
            //VideoDirection.texture = movieTextureDirctionStair;
            searchBtn.image.sprite = ResourcesDictionary[currentLanguage + "atoz"];
            bathroomSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "bathroom"];
            if (!dontAddhandi)
            {
                foreach (string cha in arrayCharacter)
                {
                    GameObject.Find(cha).GetComponent<Image>().sprite = ResourcesDictionary[cha];
                }
            }
            eventSpriteName = eventSpriteName.Replace("handi", null);
            reservedBtn.image.sprite = ResourcesDictionary[currentLanguage + eventSpriteName];
            numSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "number"];
            segmentSearchBtn.image.sprite = ResourcesDictionary[currentLanguage + "segment"];
            GameObject.Find("containresultoffice").GetComponent<Image>().sprite = ResourcesDictionary["officebackground"];
            GameObject.Find("Imagetextboxbackground").GetComponent<Image>().sprite = ResourcesDictionary["textboxbackground"];
            GameObject.Find("space").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "space"];
            GameObject.Find("backspace").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "backspace"];
            for (int i = 0; i < 10; i++)
                GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i.ToString()];
            GameObject.Find("n-130").GetComponent<Image>().sprite = ResourcesDictionary["n-130"];
            GameObject.Find("131-178").GetComponent<Image>().sprite = ResourcesDictionary["131-178"];
            GameObject.Find("n-230").GetComponent<Image>().sprite = ResourcesDictionary["n-230"];
            GameObject.Find("231-265").GetComponent<Image>().sprite = ResourcesDictionary["231-265"];
            GameObject.Find("n-330").GetComponent<Image>().sprite = ResourcesDictionary["n-330"];
            GameObject.Find("331-371").GetComponent<Image>().sprite = ResourcesDictionary["331-371"];
            GameObject.Find("401-406").GetComponent<Image>().sprite = ResourcesDictionary["401-406"];
            GameObject.Find("501-n").GetComponent<Image>().sprite = ResourcesDictionary["501-n"];
            GameObject.Find("n-q96").GetComponent<Image>().sprite = ResourcesDictionary["n-q96"];
            GameObject.Find("Panelcontainfloor1").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor1"];
            GameObject.Find("Panelcontainfloor2").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor2"];
            GameObject.Find("Panelcontainfloor3").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor3"];
            GameObject.Find("Panelcontainfloor4").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor4"];
            GameObject.Find("Panelcontainfloor5").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor5"];
            GameObject.Find("Panelcontainfloor6").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "numberfloor6"];
            GameObject.Find("pleaseselectyourletter").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorletterarrow"];
            GameObject.Find("pleaseselectyournumber").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectornumberarrow"];
            GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorofficearrow"];
            GameObject.Find("pleaseselectyoursegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorsegmentarrow"];
            if (currentBlock > 5 && currentBlock < 9)
                floorSelector.sprite = ResourcesDictionary[currentLanguage + currentBlock + "_" + currentFloor];
            else floorSelector.sprite = ResourcesDictionary[currentLanguage + "3_" + currentFloor];
            GameObject.Find("borderImg").GetComponent<Image>().sprite = ResourcesDictionary["videoFrameBar"];
            GameObject.Find("containBlockInfomation").GetComponent<Image>().sprite = ResourcesDictionary["officeInfomationBackground"];
            headerImg.color = orangeColor;
            GameObject.Find("nextEvent").GetComponent<Image>().sprite = ResourcesDictionary["next"];
            GameObject.Find("nextResult").GetComponent<Image>().sprite = ResourcesDictionary["next"];
            GameObject.Find("nextSeg").GetComponent<Image>().sprite = ResourcesDictionary["next"];
            GameObject.Find("previousEvent").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
            GameObject.Find("previousResult").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
            GameObject.Find("previousSeg").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
            GameObject.Find("CloseEvent").GetComponent<Image>().sprite = ResourcesDictionary["close"];
            GameObject.Find("CloseResult").GetComponent<Image>().sprite = ResourcesDictionary["close"];
            GameObject.Find("CloseSegment").GetComponent<Image>().sprite = ResourcesDictionary["close"];
            GameObject.Find("CloseKeyboard").GetComponent<Image>().sprite = ResourcesDictionary["close"];
            GameObject.Find("CloseNumber").GetComponent<Image>().sprite = ResourcesDictionary["close"];
            evnt1.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
            evnt2.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
            evnt3.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
            GameObject.Find("Imagetime1").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
            GameObject.Find("Imagetime2").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
            GameObject.Find("Imagetime3").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
            GameObject.Find("cinemaBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "cinemaButton"];
            GameObject.Find("theaterBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "theaterButton"];
            GameObject.Find("containCinemaTheater").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "scheduleBackground"];
        }
        isHandicapMode = !isHandicapMode;
        handicap = !handicap;
    }

    int currentFloor = 3;
    string handi = "handi";
    bool[] showAnimatioPressed = new bool[] { true, true, true, true, true, true };
    public void gotoFloor(int number)
    {
        resetTimer();
        GameObject.Find("floor" + number).GetComponent<Animator>().SetBool(m_showAnimationButtonPressed, showAnimatioPressed[number - 1]);
        showAnimatioPressed[number - 1] = !showAnimatioPressed[number - 1];
        if (number > 1)
        {
            GameObject plane = GameObject.Find("floor" + number + "_ground");
            plane.GetComponent<Renderer>().material.color = normalForFloor;
        }

        exitvideo();
        hideSearchBlock();
        if (isHandicapMode)
        {
            handi = "handi";
        }
        else
            handi = null;

        stopRoute();

        hideBlck(currentBlock, currentFloor);
        currentFloor = number;
        string floorName = currentBlock + "_" + currentFloor + handi;

        showBlck(currentBlock, currentFloor);

        floorSelector.sprite = ResourcesDictionary[currentLanguage + floorName];

        target = center;
        setCamera(orginalPostion, target);
        Debug.Log("goto floor " + floorName);

    }

    private void madeButtonTransparent(Button btn)
    {
        Color c = btn.targetGraphic.color;
        c.a = 0f;
        btn.targetGraphic.color = c;
        btn.enabled = false;
    }

    private void disableFloor(int number)
    {
        if (number < 4)
        {
            madeButtonTransparent(fl4);
        }
        if (number < 3)
        {
            madeButtonTransparent(fl3);
        }
    }

    private void showButton(Button btn)
    {
        Color c = btn.targetGraphic.color;
        c.a = 1f;
        btn.targetGraphic.color = c;
        btn.enabled = true;
    }

    private void enableAllfloor()
    {
        fl4.image.sprite = ResourcesDictionary[currentLanguage + "4"];
        showButton(fl4);

        fl3.image.sprite = ResourcesDictionary[currentLanguage + "3"];
        showButton(fl3);

        fl2.image.sprite = ResourcesDictionary[currentLanguage + "2"];
        showButton(fl2);

        fl1.image.sprite = ResourcesDictionary[currentLanguage + "1_click"];
        showButton(fl1);
    }

    private void showBlck(int numberBlock, int numberFloor)
    {
        string floorName;
        floorName = "block" + numberBlock + "_" + numberFloor;

        currentBlock = numberBlock;
        Vector3 postion = PositnBlock[floorName];

        GameObject.Find(floorName).transform.position = postion;
    }

    private void hideBlck(string floorName)
    {
        Vector3 postion = PositnBlock[floorName + "h"];
        Debug.Log(floorName);
        GameObject.Find(floorName).transform.position = postion;
    }

    private void hideBlck(int numberBlock, int numberFloor)
    {
        string floorName;
        floorName = "block" + numberBlock + "_" + numberFloor;
        //Debug.Log (floorName);

        Vector3 postion = PositnBlock[floorName + "h"];
        GameObject.Find(floorName).transform.position = postion;
    }

    private void hideRangeNuber()
    {
        GameObject.Find(currentNameLayoutShow).GetComponent<Animator>().SetBool(m_OpenParameterId, false);
        currentNameLayoutShow = null;
        //containRangeNumber.enabled = false;
        //ctnRange.enabled = false;
    }

    //Dictionary<string, MovieTexture> libariVideo = new Dictionary<string, MovieTexture> ();
    public static bool currentvideo;

    public DragVideo draggggg;

    private void showOfficeVideo()
    {
        //isShowVideo (true);
        StartCoroutine(playOfficeVideo());
    }

    IEnumerator LoadVideo(string url)
    {
        //Debug.Log (url);
        currentvideo = false;
        draggggg.loadVideoFromUrl(fullPathVideoFolder + "video/" + url, showOfficeVideo);
        yield return 1;
    }

    /*
	private IEnumerator LoadVideo(string url)
	{
		currentvideo = url;
		isShowVideo (false);
		videoOffice.texture = null;
		MovieTexture movieTexture;

		if (libariVideo.ContainsKey (url)) {
			//Debug.Log("use old movie!!");
			movieTexture = libariVideo[url];
		} else {
			WWW www = new WWW(url);
			movieTexture = www.movie;			
			while (!movieTexture.isReadyToPlay) {
				yield return null;
			}
			libariVideo.Add(url,movieTexture);
			//Debug.Log("download new movie!!");
		}

		//Debug.Log ("Movie alredy!!");
		movieTexture.loop = true;
		videoOffice.texture = movieTexture;
		movieTexture.Play();
		isShowVideo (true);
		yield return null;
		
	}
	*/

    public void rangeBtnPress(string number)
    {
        resetTimer();
        hideRangeNuber();
        StartCoroutine(searchOfficeInRange(number));
    }

    List<string> tempArray = new List<string>();
    Dictionary<string, string[]> sortDic = new Dictionary<string, string[]>();
    public IEnumerator searchOfficeInRange(string number)
    {
        //log_debug = "\nnumber:"+number;
        char searchInFloor = '1';
        yield return new WaitForSeconds(0.2F);//for 64bit
        string[] arrayInfo = null;
        int min = 0, max = 0;
        bool firIsCharacter = false;
        if (number.IndexOf("-") >= 0)
        {
            arrayInfo = number.Split(new string[] { "-" }, System.StringSplitOptions.None);
            searchInFloor = arrayInfo[0][0];
            if (arrayInfo[1] == "all")
            {
                min = max = -1;
            }
            else
            {
                if (arrayInfo[1] != "n")
                    min = int.Parse(arrayInfo[1]);
                else
                {
                    firIsCharacter = true;
                    min = int.Parse(searchInFloor.ToString()) * 100;
                }
                max = int.Parse(arrayInfo[2]);
            }
        }
        bool haveResult = false;
        cleanTexture();
        tempArray.Clear();
        sortDic.Clear();
        int index = 0;
        Debug.Log("min:" + min + ",max:" + max);
        foreach (string x in infomationForSearch)
        {
            if (x != "")
            {
                string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                if (info[0][2] == searchInFloor)
                {
                    //Debug.Log(checkInRange(info[2],min,max)+"_"+info[2]);
                    if ((
                        (firIsCharacter && (info[2][0] == 'n' || info[2][0] == 'N' || info[2][0] == 'q' || info[2][0] == 'Q' || checkInRange(info[2], min, max))) ||
                        (!firIsCharacter && info[2][0] != 'n' && checkInRange(info[2], min, max))
                        )
                        &&
                        info[1] != "for_empty_office")
                    {
                        //System.enc
                        index++;
                        haveResult = true;
                        tempArray.Add(info[2] + "_" + index);
                        sortDic.Add(info[2] + "_" + index, info);
                    }
                }
            }
        }
        if (haveResult)
        {
            tempArray.Sort();
            foreach (string name in tempArray)
            {
                string[] info = sortDic[name];
                //log_debug += "\n"+string.Join(",",info);
                StartCoroutine(loadTexture4Office(info[0], toNormalString(info[2]), toNormalString(info[4]), currentIndex, convertToUtf8(toNormalString(info[1])), toNormalString(info[2])));
                if (currentIndex < maxOffice)
                    currentIndex++;
            }
            GameObject.Find("PanelContainresults").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
            currentNameLayoutShow = "PanelContainresults";
            cleanAllOffice(currentIndex);
        }
        else
            hideFullTransparent();
        yield return null;
    }

    public string convertToUtf8(string input)
    {
        byte[] nameByteArray = System.Text.Encoding.Default.GetBytes(input);
        return System.Text.Encoding.UTF8.GetString(nameByteArray);
    }

    bool checkInRange(string text, int min, int max)
    {
        if (min == max && min == -1)
            return true;
        if (max > min)
        {
            for (int i = min; i <= max; i++)
            {
                if (text.IndexOf(i.ToString()) >= 0)
                    return true;
            }
        }
        return false;
    }

    bool isShowTime = false;
    private void OnShowTimedEvent(object o, System.Timers.ElapsedEventArgs e)
    {
        isShowTime = true;
    }


    bool isShowFullScreen = false, changeStatusScreen = false;
    private void OnShowFullScreenEvent(object o, System.Timers.ElapsedEventArgs e)
    {
        if (!isShowFullScreen)
        {
            changeStatusScreen = true;
            isShowFullScreen = true;
        }
    }

    bool isHideInfomation = false;
    private void OnShowHideInfoEvent(object o, System.Timers.ElapsedEventArgs e)
    {
        isHideInfomation = true;
    }

    bool isCloseCinema = false;
    private void OnCloseCinema(object o, System.Timers.ElapsedEventArgs e)
    {
        isCloseCinema = true;
    }

    bool isStopApplication = false;
    private void OnTimedBoomEvent(object o, System.Timers.ElapsedEventArgs e)
    {
        //isStopApplication = true;
    }

    private void OnTimedEvent(object o, System.Timers.ElapsedEventArgs e)
    {
        //Debug.Log("update sence");
        //update = true;
    }

    private void LoadNextCarousel(object o, System.Timers.ElapsedEventArgs e)
    {
        shownextCarousel = true;
    }

    private void updateArrow(bool isStore)
    {
        if (isStore)
        {
            if (!isHandicapMode)
                GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorstorearrow"];
            else
                GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorstorearrowhandi"];
        }
        else
        {
            if (!isHandicapMode)
                GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorofficearrow"];
            else
                GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "selectorofficearrowhandi"];
        }
    }

    public void searchPress()
    {
        resetTimer();

        updateArrow(true);

        hideEventAndInfomation();
        //hideBlockSelector ();
        exitvideo();

        hideOldeScreen();

        showFullTransparent();
        officeFliter.text = null;
        KeycleanAllOffice(0);

        GameObject.Find("Panelcontainkey").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
        currentNameLayoutShow = "Panelcontainkey";
    }


    bool changesize = true;
    Vector2 normalSize = new Vector2(332, 202);
    Vector2 bigSize = new Vector2(408, 272);
    public void resize()
    {
        //Debug.Log("resize click!!!!!!!!!!!1");
        if (changesize)
        {
            containvideoOffice.rectTransform.sizeDelta = bigSize;
            //containvideoOffice.GetComponent<RectTransform> ().anchoredPosition = vectorResetVideoBig;
            //videoOffice.customScreenRect.size = bigSize;
            draggggg.updateLocationVideo(204, 136, bigSize);
        }
        else
        {
            containvideoOffice.rectTransform.sizeDelta = normalSize;
            //videoOffice.customScreenRect.size = normalSize;
            draggggg.updateLocationVideo(167f, 101f, normalSize);
        }
        changesize = !changesize;
    }
    //Vector2 vectorResetVideoBig = new Vector2(217.55f, 315f);
    Vector2 vectorResetVideo = new Vector2(180.55f, 271.5f);
    public void exitvideo()
    {
        //videoOffice.texture
        if (stillShowVideoDirection)
        {
            hideVideoDirection(false);
        }
        if (currentvideo)
        {
            draggggg.exitVideo();
            currentOfficeVideoIndex = null;
            /*if (libariVideo.ContainsKey (currentvideo)) {
				if (libariVideo [currentvideo] != null){
					libariVideo [currentvideo].Stop ();
					videoOffice.GetComponent<RectTransform> ().anchoredPosition = vectorResetVideo;
					//Debug.Log("exit video");
				}
			}*/
            containvideoOffice.GetComponent<RectTransform>().anchoredPosition = vectorResetVideo;
            if (!changesize)
                resize();
            isShowVideo(false);
        }
    }

    public void isShowVideo(bool isShow)
    {
        if (isShow)
        {
            GameObject.Find("borderImg").GetComponent<Image>().enabled = true;
            containvideoOffice.enabled = true;
            //videoOffice.drawToScreen = true;
            exitViedo.gameObject.SetActive(true);
            resizeVideo.gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("borderImg").GetComponent<Image>().enabled = false;
            containvideoOffice.enabled = false;
            //videoOffice.drawToScreen = false;
            exitViedo.gameObject.SetActive(false);
            resizeVideo.gameObject.SetActive(false);
        }
    }

    string[] infomationOfName;
    string[] infomationForSearch;
    string[] infomationCarousel;
    string[] infomationEvents;
    string[] infomationCinema;
    string[] infomationTheater;
    bool firstLoad = true;

    public IEnumerator sysServer()
    {
        string result = string.Empty;
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/src/infomation");
            infomationForSearch = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
            StartCoroutine(repareNameForSearch());
        }
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/crs/infomation");
            infomationCarousel = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
        }
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/event/infomation");
            infomationEvents = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
        }
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/cinema/infomation");
            infomationCinema = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
        }
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/theater/infomation");
            infomationTheater = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
        }
        if (firstLoadCarousel)
        {

            firstLoadCarousel = false;

            carouselTimer = new System.Timers.Timer();

            carouselTimer.Elapsed += LoadNextCarousel;

            carouselTimer.Stop();
            if (infomationCarousel.Length > 1)
                StartCoroutine(loadcrosel());
        }
        if (!stillUpdatingLogo)
            StartCoroutine(updateLogo());
        yield return null;
    }

    public IEnumerator repareNameForSearch()
    {
        infomationOfName = new string[infomationForSearch.Length];
        string temp;
        for (int i = 0; i < infomationForSearch.Length; i++)
        {
            string x = infomationForSearch[i];
            if (x != "")
            {
                temp = "";
                string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                string name = convertToUtf8(toNormalString(info[1])).ToLower();

                foreach (char ch in name)
                {
                    if (ch != '.' && ch != '\'')
                        temp += getChar(ch);
                }
                infomationOfName[i] = temp;
            }
        }
        Debug.Log("finished!!!!" + infomationOfName.Length);
        yield return null;
    }

    public Dictionary<string, Vector3> dicPoint = new Dictionary<string, Vector3>();
    public IEnumerator addNewOffice()
    {
        string result;
        dicPoint.Clear();
        string line;
        string block, floor;
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/newoffice/points");
            string[] pointArray = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
            foreach (string pointInf in pointArray)
            {
                if (pointInf != "" && pointInf != null)
                {
                    string[] pointA = pointInf.Split(new string[] { " " }, System.StringSplitOptions.None);
                    dicPoint.Add(pointA[0], new Vector3(float.Parse(pointA[1]), 1.5F, float.Parse(pointA[2])));
                    //Debug.Log(dicPoint[pointA[0]]);
                }
            }
        }
        using (var webClient = new System.Net.WebClient())
        {
            result = webClient.DownloadString(IP + "/newoffice/routes");
            string[] officeArray = result.Split(new string[] { ":" }, System.StringSplitOptions.None);
            foreach (string officeInf in officeArray)
            {
                if (officeInf != "" && officeInf != null)
                {
                    string[] officeA = officeInf.Split(new string[] { " " }, System.StringSplitOptions.None);
                    block = officeA[0][1].ToString();
                    floor = officeA[0][2].ToString();
                    string nameOffice = officeA[0].Substring(3);
                    string[] routeInfo = officeA[1].Split(new string[] { "," }, System.StringSplitOptions.None);
                    Vector3[] routeAppend = new Vector3[routeInfo.Length - 1];
                    for (int i = 1; i < routeInfo.Length; i++)
                    {
                        routeAppend[i - 1] = dicPoint["b" + block + floor + routeInfo[i]];
                    }
                    if (floor == "1")
                    {
                        block8_1Info.addNewOffice("office" + nameOffice, routeInfo[0], routeAppend, "office" + officeA[2]);
                        block8_1Infohandicap.addNewOffice("office" + nameOffice, routeInfo[0], routeAppend, "office" + officeA[2]);
                    }
                    else if (floor == "2")
                    {
                        block8_2Info.addNewOffice("office" + nameOffice, routeInfo[0], routeAppend, "office" + officeA[2]);
                        block8_2Infohandicap.addNewOffice("office" + nameOffice, routeInfo[0], routeAppend, "office" + officeA[2]);
                    }
                    else if (floor == "3")
                    {
                        block8_3Info.addNewOffice("office" + nameOffice, routeInfo[0], routeAppend, "office" + officeA[2]);
                    }
                    else if (floor == "4")
                    {
                        //block8_4Info.addNewOffice("office"+nameOffice,routeInfo[0],routeAppend,"office"+officeA[2]);
                    }
                }
            }
        }
        dicPoint.Clear();
        yield return null;
    }

    List<string> listNameCurrentBlock = new List<string>();
    bool isHandicapMode = false, havenextcamera = false, havethirdcamera = false;
    Color transparentForFloor = new Color(1.0f, 1.0f, 1.0f, 0.25f);
    Color normalForFloor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    Vector3 orgP = new Vector3(0, 0, 0);
    Vector3 orgPChange = new Vector3(0, 0, 0);
    Vector3 orgPChange1 = new Vector3(0, 0, 0);
    Vector3 orgPChange2 = new Vector3(0, 0, 0);
    Vector3 cameraPostion = new Vector3(328.19f, 49.61f, 260.46f);
    Vector3[] changeStair1, changeStair2, changeStair;

    //string log_debug = "";
    public void getRoute(string name)
    {
        try
        {
            int newLengthList2 = 0;
            bool dontStartTimer = false;
            havenextcamera = false;
            havethirdcamera = false;

            Vector3 lkk = Vector3.zero;

            nameCameraPostion = name.Replace("office", null);
            result = "\nstatic Vector3 " + currentBlock + "_" + currentFloor + name + " = new Vector3 ";
            //Debug.Log (name);
            string namefloor = "block" + currentBlock + "_" + currentFloor;
            //Debug.Log (namefloor);
            Vector3[] list = null, list2 = new Vector3[0];
            if (namefloor == "block8_1")
            {

                //Debug.Log (name);
                if (isHandicapMode)
                {
                    list = block8_1Infohandicap.dictionary[name];
                    list2 = block8_3Info.dictionary["evelator"];
                    cameraPostion = block8_2Info.PositnCamera["evelatordown"];
                    lkk = block8_2Info.LookatCamera["evelatordown"];
                    newLengthList2 = list2.Length;
                }
                else
                {
                    list = block8_1Info.dictionary[name];
                    list2 = block8_3Info.dictionary["stairdown"];
                    cameraPostion = block8_3Info.PositnCamera["stairdown"];
                    lkk = block8_3Info.LookatCamera["stairdown"];
                    changeStair1 = block8_2Info.dictionary["changestair"];
                    newLengthList2 = list2.Length + changeStair1.Length;
                    orgPChange2 = GameObject.Find("block8_2transparent").transform.position;
                }

                listpoint = new Vector3[list.Length + newLengthList2];
                orgP = GameObject.Find("block8_3").transform.position;
                int oldLength = list2.Length;
                orgPChange1 = GameObject.Find("block8_2transparent").transform.position;

                for (int i = 0; i < newLengthList2; i++)
                {
                    if (i < oldLength)
                        listpoint[i] = ratetio * list2[i] + orgP;
                    else if (i < oldLength + changeStair1.Length)
                        listpoint[i] = ratetio * changeStair1[i - oldLength] + orgPChange1;
                }

                orgP = GameObject.Find(namefloor).transform.position;

                posss = block8_1Info.PositnCamera[name];
                lattt = block8_1Info.LookatCamera[name];
                havenextcamera = true;
                havethirdcamera = true;

            }
            else if (namefloor == "block8_2")
            {
                //Debug.Log (name);
                if (isHandicapMode)
                {
                    list = block8_2Infohandicap.dictionary[name];
                    list2 = block8_3Info.dictionary["evelator"];
                    cameraPostion = block8_2Info.PositnCamera["evelatordown"];
                    lkk = block8_2Info.LookatCamera["evelatordown"];
                    newLengthList2 = list2.Length;
                }
                else
                {
                    list = block8_2Info.dictionary[name];
                    list2 = block8_3Info.dictionary["stairdown"];
                    cameraPostion = block8_3Info.PositnCamera["stairdown"];
                    lkk = block8_3Info.LookatCamera["stairdown"];
                }

                listpoint = new Vector3[list.Length + list2.Length];

                orgP = GameObject.Find("block8_3").transform.position;

                for (int i = 0; i < list2.Length; i++)
                {
                    listpoint[i] = ratetio * list2[i] + orgP;
                }

                orgP = GameObject.Find(namefloor).transform.position;

                posss = block8_2Info.PositnCamera[name];
                lattt = block8_2Info.LookatCamera[name];
                havenextcamera = true;

            }
            else if (namefloor == "block8_3")
            {

                list = block8_3Info.dictionary[name];

                listpoint = new Vector3[list.Length];

                orgP = GameObject.Find(namefloor).transform.position;

                cameraPostion = block8_3Info.PositnCamera[name];
                //orginalPostion, target);

                lkk = block8_3Info.LookatCamera[name];

            }
            else if (namefloor == "block8_4")
            {

                //Debug.Log (name);
                if (isHandicapMode)
                {
                    list = block8_4Infohandicap.dictionary[name];
                    list2 = block8_3Info.dictionary["evelator"];
                    cameraPostion = block8_2Info.PositnCamera["evelatordown"];
                    lkk = block8_2Info.LookatCamera["evelatordown"];
                    newLengthList2 = list2.Length;
                }
                else
                {
                    list = block8_4Info.dictionary[name];
                    list2 = block8_3Info.dictionary["stairup"];
                    cameraPostion = block8_2Info.PositnCamera["stairup"];
                    lkk = block8_2Info.LookatCamera["stairup"];
                }

                listpoint = new Vector3[list.Length + list2.Length];

                orgP = GameObject.Find("block8_3").transform.position;

                Debug.Log(orgP);

                for (int i = 0; i < list2.Length; i++)
                {
                    listpoint[i] = ratetio * list2[i] + orgP;
                }

                orgP = GameObject.Find(namefloor).transform.position;

                posss = block8_4Info.PositnCamera[name];
                lattt = block8_4Info.LookatCamera[name];
                havenextcamera = true;

            }
            else if (namefloor == "block8_5")
            {
                //Debug.Log (name);
                if (isHandicapMode)
                {
                    list = block8_5Infohandicap.dictionary[name];
                    list2 = block8_3Info.dictionary["evelator"];
                    cameraPostion = block8_2Info.PositnCamera["evelatordown"];
                    lkk = block8_2Info.LookatCamera["evelatordown"];
                    newLengthList2 = list2.Length;
                }
                else
                {
                    list = block8_5Info.dictionary[name];
                    list2 = block8_3Info.dictionary["stairup"];
                    cameraPostion = block8_2Info.PositnCamera["stairup"];
                    lkk = block8_2Info.LookatCamera["stairup"];
                }

                listpoint = new Vector3[list.Length + list2.Length];

                orgP = GameObject.Find("block8_3").transform.position;

                for (int i = 0; i < list2.Length; i++)
                {
                    listpoint[i] = ratetio * list2[i] + orgP;
                }

                orgP = GameObject.Find(namefloor).transform.position;

                posss = block8_4Info.PositnCamera[name];
                lattt = block8_4Info.LookatCamera[name];
                havenextcamera = true;
            }
            else if (namefloor == "block8_6")
            {
                //Debug.Log (name);
                if (isHandicapMode)
                {
                    list = block8_6Infohandicap.dictionary[name];
                    list2 = block8_3Info.dictionary["evelator"];
                    cameraPostion = block8_2Info.PositnCamera["evelatordown"];
                    lkk = block8_2Info.LookatCamera["evelatordown"];
                    newLengthList2 = list2.Length;
                }
                else
                {
                    list = block8_6Info.dictionary[name];
                    list2 = block8_3Info.dictionary["stairup"];
                    cameraPostion = block8_2Info.PositnCamera["stairup"];
                    lkk = block8_2Info.LookatCamera["stairup"];
                }

                listpoint = new Vector3[list.Length + list2.Length];

                orgP = GameObject.Find("block8_3").transform.position;

                for (int i = 0; i < list2.Length; i++)
                {
                    listpoint[i] = ratetio * list2[i] + orgP;
                }

                orgP = GameObject.Find(namefloor).transform.position;

                posss = block8_6Info.PositnCamera[name];
                lattt = block8_6Info.LookatCamera[name];
                havenextcamera = true;
            }


            if (list2.Length > 0)
            {
                GameObject plane;
                showVideoDireciton(namefloor);
                if (namefloor != "block8_1")
                {
                    plane = GameObject.Find("floor" + namefloor[7] + "_ground");
                    plane.GetComponent<Renderer>().material.color = transparentForFloor;
                }
                plane = GameObject.Find("floor3_ground");
                plane.GetComponent<Renderer>().material.color = transparentForFloor;
            }
            else
            {
                if (!dontStartTimer)
                {
                    hideInfomationTimer.Stop();
                    hideInfomationTimer.Start();
                    //Debug.Log("start time");
                }
                //StartCoroutine (LoadVideo (currentOfficeVideoIndex + videoType));
                StartCoroutine(Wait(loadOfficeVideoByPath));
            }
            if (newLengthList2 == 0)
                newLengthList2 = list2.Length;
            for (int i = 0; i < (list.Length); i++)
            {
                listpoint[i + newLengthList2] = ratetio * list[i] + orgP;
            }
            //startAnimation.transform.position = listpoint [0];
            printPoint.transform.position = listpoint[listpoint.Length - 1];

            if (!isBathRoomSearch)
            {
                endAnimation.transform.position = listpoint[listpoint.Length - 1] - new Vector3(0, 1.8f, 0);
            }
            else
            {
                if (endAnimation == null)
                {
                    endAnimation = GameObject.Find("containAnimation");
                    if (endAnimation == null)
                    {
                        endAnimation = Instantiate(Resources.Load("containAnimation", typeof(GameObject))) as GameObject;
                        endAnimation.name = "containAnimation";
                    }
                }
                GameObject endpathroom = GameObject.Instantiate(endAnimation) as GameObject;
                endpathroom.name = "endpathroom";
                endpathroom.transform.position = listpoint[listpoint.Length - 1] - new Vector3(0, 1.8f, 0);
            }

            Vector3 start = listpoint[0];
            startPoint = true;
            for (int i = 1; i < listpoint.Length; i++)
            {
                create_vessel(start, listpoint[i], i);
                start = listpoint[i];
            }

            if (isBathRoomSearch && name == "office71")
            {
                cameraPostion = block8_3Info.PositnCamera[name];
                lkk = block8_3Info.LookatCamera[name];
                isBathRoomSearch = false;
            }
            if (!(isBathRoomSearch && (name == "office70")))
            {
                setCamera(cameraPostion, lkk);
            }
        }
        catch (System.Exception e)
        {
            //log_debug += "\nofficeName:" + name + ", " + e.ToString ();
            Debug.Log("\nofficeName:" + name + ", " + e.ToString());
        }
        //writetofile.append2File (buginfo, log_debug);
        //log_debug = "";
    }

    bool stillShowVideoDirection = false;
    void showVideoDireciton(string name)
    {

        stillShowVideoDirection = true;

        if (name == "block8_1" || name == "block8_2")
        {
            if (isHandicapMode)
                VideoDirection.texture = movieTextureElevatorDown;
            else
                VideoDirection.texture = movieTextureStairDown;
        }
        else
        {
            if (isHandicapMode)
                VideoDirection.texture = movieTextureDirctionElevator;
            else
                VideoDirection.texture = movieTextureDirctionStair;
        }

        ((MovieTexture)VideoDirection.texture).Play();
        GameObject.Find("containVideoDirction").GetComponent<Animator>().SetBool(m_showDirctionVideoId, true);
        //currentNameLayoutShow = "containVideoDirction";
    }
    bool haveShowVideoDirection = false;
    void hideVideoDirection(bool loadOfficeVideo)
    {
        stillShowVideoDirection = false;
        haveShowVideoDirection = false;
        ((MovieTexture)VideoDirection.texture).Stop();
        GameObject.Find("containVideoDirction").GetComponent<Animator>().SetBool(m_showDirctionVideoId, false);
        if (loadOfficeVideo)
        {
            StartCoroutine(Wait(loadOfficeVideoByPath));
        }
    }

    void loadOfficeVideoByPath()
    {
        StartCoroutine(LoadVideo(currentOfficeVideoIndex + videoType));
    }

    void showTransparent(string name, float height)
    {

        GameObject ga = GameObject.Find(name);
        ga.transform.position = new Vector3(ga.transform.position.x, height, ga.transform.position.z);

    }

    void showFullTransparent(string name, float height)
    {
        GameObject ga = GameObject.Find(name);
        ga.transform.position = new Vector3(ga.transform.position.x, height, ga.transform.position.z);
    }

    void setCamera(Vector3 postion, Vector3 lookAt)
    {
        StartCoroutine(LerpToPosition(transitionDuration, postion, lookAt));
        target = lookAt;
    }
    float speedRotate = 20f;
    Vector3 target;
    public void arroundLeft()
    {
        //flatStart.transform.LookAt (Camera.main.transform);
        Camera.main.transform.LookAt(target);
        Camera.main.transform.RotateAround(target, Vector3.up, speedRotate * Time.deltaTime);
    }
    public void arroundRight()
    {
        //flatStart.transform.LookAt (Camera.main.transform);
        Camera.main.transform.LookAt(target);
        Camera.main.transform.RotateAround(target, Vector3.down, speedRotate * Time.deltaTime);
    }
    public void arroundUp()
    {
        if (Vector3.Angle(Camera.main.transform.up, Vector3.up) < 85)
        {
            //flatStart.transform.LookAt (Camera.main.transform);
            Camera.main.transform.LookAt(target);
            Camera.main.transform.RotateAround(target, Camera.main.transform.right, speedRotate * Time.deltaTime);
        }
    }
    public void arroundDown()
    {
        if (Vector3.Angle(Camera.main.transform.up, Vector3.up) > 5)
        {
            //flatStart.transform.LookAt (Camera.main.transform);
            Camera.main.transform.LookAt(target);
            Camera.main.transform.RotateAround(target, -Camera.main.transform.right, speedRotate * Time.deltaTime);
        }
    }
    public void cameraForward()
    {
        //Vector3 forward = new Vector3 (Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
        Camera.main.transform.Translate(Camera.main.transform.forward * -5);
    }
    public void cameraBackward()
    {
        Camera.main.transform.RotateAround(target, -Camera.main.transform.right, speedRotate * Time.deltaTime);
    }

    void hideSearchBlock()
    {
        foreach (string x in listNameCurrentBlock)
        {
            //Debug.Log(x);
            hideBlck(x);
        }
        listNameCurrentBlock.Clear();
    }

    public void OnNextButtonEvent()
    {
        resetTimer();
        StartCoroutine(officeClick(null));
    }

    bool showRouteBettwenBlock = false;
    string nameOfSearchBlock, routeBettwenBlock;

    public void officeClickEvent(Button name)
    {
        resetTimer();
        StartCoroutine(officeClick(name));
    }

    private IEnumerator officeClick(Button name)
    {
        string blcName;
        string officeIndex;
        if (currentNameLayoutShow != null && name != null)
        {
            GameObject.Find(currentNameLayoutShow).GetComponent<Animator>().SetBool(m_OpenParameterId, false);
            currentNameLayoutShow = null;
        }

        if (name != null)
        {
            blcName = name.image.sprite.name;
            officeIndex = blcName.Split(new string[] { "+" }, System.StringSplitOptions.None)[0];

            //Debug.Log(blcName);

            GameObject.Find("containBlockInfomation").GetComponent<Animator>().SetBool(m_showScreenParameterId, true);
            reservedBtn.GetComponent<Animator>().SetBool(m_ShowEventParameterId, true);

            string numberOfFloor = officeIndex[2].ToString();
            //Debug.Log(officeIndex[1]);
            if (officeIndex[1] != '8' && officeIndex[1] != '7')
            {
                numberOfFloor = (int.Parse(numberOfFloor) - 1).ToString();
            }
            if (currentLanguage == null || currentLanguage == "")
                floorOfficeOn.text = "Floor " + numberOfFloor + " - " + DicNumberOffice[blcName];
            else floorOfficeOn.text = "Andar " + numberOfFloor + " - " + DicNumberOffice[blcName];
            officePhoneNumber.text = DicphoneNumber[blcName];
            officeLogo.sprite = name.image.sprite;
            officeShowName.text = listNameOffie[blcName];

            if (officeIndex.IndexOf("b8") < 0)
            {
                nameOfSearchBlock = officeIndex;
                officeIndex = "b81231";
                showRouteBettwenBlock = true;
                routeBettwenBlock = "b91" + nameOfSearchBlock[1];
            }
        }
        else if (showRouteBettwenBlock)
        {
            officeIndex = routeBettwenBlock;
            showRouteBettwenBlock = false;
        }
        else
        {
            officeIndex = nameOfSearchBlock;
        }


        hideSearchBlock();

        stopRoute();

        hideBlck(currentBlock, currentFloor);

        int Block = int.Parse(officeIndex[1].ToString());
        int Floor = int.Parse(officeIndex[2].ToString());

        string nameBlock = "block" + Block + "_" + Floor;


        if (Floor > 3)
        {
            float height = 36 / (Floor - 1);
            for (int i = 1; i < Floor; i++)
            {
                string n = "block" + Block + "_" + i + "transparent";
                if (i == 1)
                    showFullTransparent(n, 0.2f);
                else if (i == 3)
                    showFullTransparent("block8_3", height * (i - 1));
                else
                    showFullTransparent(n, height * (i - 1));
                if (i != 3)
                    listNameCurrentBlock.Add(n);
            }
        }
        if (Floor == 1)
        {
            showBlck(Block, 1);
            showTransparent("block8_2transparent", 13);
            showTransparent("block8_3", 36);
            listNameCurrentBlock.Add("block8_2transparent");
        }
        else if (Floor == 2)
        {
            showFullTransparent("block8_1transparent", 0.2f);
            showTransparent("block8_2", 13);
            showTransparent("block8_3", 36);
            listNameCurrentBlock.Add("block8_1transparent");
        }
        else if (Floor == 3)
        {
            showBlck(Block, 3);
        }
        else if (Floor > 3)
        {
            showTransparent(nameBlock, 36);
            listNameCurrentBlock.Add(nameBlock);
        }


        listNameCurrentBlock.Add("block8_3");
        //showBlck (Block, 2);
        currentBlock = Block;
        currentFloor = Floor;
        currentOfficeVideoIndex = officeIndex;
        getRoute("office" + officeIndex.Substring(3));
        //StartCoroutine (LoadVideo (officeIndex + videoType));
        StartCoroutine(waitforresult());
        yield return null;
    }

    string currentOfficeVideoIndex = null;

    public IEnumerator waitforresult()
    {
        yield return new WaitForSeconds(1F);
        hideFullTransparent();
    }
    Vector3 hidePrintPoint = new Vector3(0, 1000, 0);
    void stopRoute()
    {
        //startAnimation.transform.position = hideStartPoint;
        endAnimation.transform.position = hideEndPoint;
        printPoint.transform.position = hidePrintPoint;

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            string nameobj = gameObj.name;
            if (nameobj == "lineDirection" || nameobj == "ball" || nameobj == "endpathroom")
            {
                Destroy(gameObj);
            }
        }
    }

    float indexofbutton = 0f;

    int maxNumberOffice = 6;

    private Vector3 getNextPostion()
    {
        int y = (int)indexofbutton / maxNumberOffice;
        int x = (int)((indexofbutton % maxNumberOffice));
        indexofbutton += 1;
        return new Vector3(-500 + x * 200, 200 - y * 150, 0);
    }

    void cleanAllOffice(int begin)
    {
        for (int i = begin; i < maxOffice; i++)
        {
            var plane = GameObject.Find("Btn" + i).GetComponent<Button>();
            Color c = plane.targetGraphic.color;
            c.a = 0f;
            plane.targetGraphic.color = c;
            plane.enabled = false;


            var img = GameObject.Find("p" + i).GetComponent<Image>();
            img.enabled = false;

            var t = GameObject.Find("of" + i).GetComponent<Text>();
            t.enabled = false;
        }
    }

    void showFullTransparent()
    {
        GameObject.Find("backgroundtransparent").GetComponent<Image>().enabled = true;
        GameObject.Find("carImg").GetComponent<Image>().enabled = false;
        GameObject.Find("Imgsearch").GetComponent<Image>().enabled = false;
        GameObject.Find("leftImg").GetComponent<Image>().enabled = false;
    }

    void hideFullTransparent()
    {
        GameObject.Find("backgroundtransparent").GetComponent<Image>().enabled = false;
        GameObject.Find("carImg").GetComponent<Image>().enabled = true;
        GameObject.Find("Imgsearch").GetComponent<Image>().enabled = true;
        GameObject.Find("leftImg").GetComponent<Image>().enabled = true;
    }

    int keycurrentIndex = 0, keymaxOffice = 6;
    public IEnumerator searchOffice(string name)
    {
        yield return new WaitForSeconds(0.5F);
        keycurrentIndex = 0;
        cleanTexture();
        tempArray.Clear();
        sortDic.Clear();
        int index = 0;
        for (int i = 0; i < infomationOfName.Length; i++)
        {
            string x = infomationOfName[i];
            if (x != "" && x != null)
            {
                if (x.IndexOf(name) >= 0 && x != "for_empty_office")
                {
                    string[] info = infomationForSearch[i].Split(new string[] { " " }, System.StringSplitOptions.None);
                    index++;
                    //haveResult=true;
                    tempArray.Add(info[1] + "_" + index);
                    sortDic.Add(info[1] + "_" + index, info);
                    //Debug.Log(info[1]);
                }
            }
        }
        //if (haveResult) 
        {
            tempArray.Sort();
            foreach (string names in tempArray)
            {
                string[] info = sortDic[names];
                //log_debug += "\n"+string.Join(",",info);
                StartCoroutine(loadTexttureforOfficeKeyboard(info[0], convertToUtf8(toNormalString(info[1])), toNormalString(info[4]), keycurrentIndex, null, toNormalString(info[2])));
                if (keycurrentIndex < keymaxOffice)
                    keycurrentIndex++;
            }
            //Debug.Log(keycurrentIndex);
            KeycleanAllOffice(keycurrentIndex);
        }
        yield return null;
    }

    void KeycleanAllOffice(int begin)
    {
        for (int i = begin; i < keymaxOffice; i++)
        {
            var plane = GameObject.Find("kBtn" + i).GetComponent<Button>();
            Color c = plane.targetGraphic.color;
            c.a = 0f;
            plane.targetGraphic.color = c;
            plane.enabled = false;


            var img = GameObject.Find("kp" + i).GetComponent<Image>();
            img.enabled = false;

            var t = GameObject.Find("kof" + i).GetComponent<Text>();
            t.enabled = false;
        }
    }

    public IEnumerator loadTexttureforOfficeKeyboard(string name, string nameOffice, string phoneNumber, int index, string subNameOffice, string officeNumber)
    {
        //if (gameObject != null) 
        {
            Text texts = null;
            Button buttons = null;

            TextureBtn.Add(name);
            nameOffices.Add(nameOffice);
            if (subNameOffice != null)
            {
                listNameOffie.Add(name, subNameOffice);
            }
            else
            {
                listNameOffie.Add(name, nameOffice);
            }
            if (index < keymaxOffice)
            {

                GameObject.Find("kp" + index).GetComponent<Image>().enabled = true;
                texts = GameObject.Find("kof" + index).GetComponent<Text>();
                buttons = GameObject.Find("kBtn" + index).GetComponent<Button>();
            }
            Sprite sprite;
            if (!spriteSave.ContainsKey(name))
            {
                string fullPathFile = "C:/server/logo/" + name + imageType;
                byte[] data = File.ReadAllBytes(fullPathFile);
                Texture2D texture = new Texture2D(87, 87, TextureFormat.ARGB32, false);
                texture.LoadImage(data);

                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                spriteSave.Add(name, sprite);
                //Debug.Log(name+":"+texture.width);
            }
            else
            {
                sprite = spriteSave[name];
            }
            if (!DicphoneNumber.ContainsKey(name))
            {
                DicphoneNumber.Add(name, phoneNumber);
            }
            if (!DicNumberOffice.ContainsKey(name))
            {
                DicNumberOffice.Add(name, officeNumber);
            }
            sprite.name = name;
            if (buttons != null && texts != null)
            {

                texts.enabled = true;
                texts.text = nameOffice;

                buttons.enabled = true;
                buttons.image.sprite = sprite;
                Color c = buttons.targetGraphic.color;
                c.a = 255f;
                buttons.targetGraphic.color = c;
            }
        }
        yield return null;
    }

    private char getChar(char c)
    {
        if (c == ' ')
            return c;
        else if ("a ã ă á ắ ấ à ằ ầ ặ â ậ A Ă Á Ắ Ấ Â À Ằ Ầ Ặ Ậ".IndexOf(c) >= 0)
            return 'a';
        else if ("e é ế è ề ê ẹ ệ E É Ê Ế È Ề Ẹ &".IndexOf(c) >= 0)
            return 'e';
        else if ("i í ì ị I Í Ì Ị".IndexOf(c) >= 0)
            return 'i';
        else if ("o õ ò ồ ố ô ó ọ ộ O Ò Ồ Ố Ô Ó Ọ Ộ".IndexOf(c) >= 0)
            return 'o';
        else if ("u ú ù ụ U Ú Ù Ụ".IndexOf(c) >= 0)
            return 'u';
        else if ('ç' == c)
            return 'c';
        else return c;

    }

    private void cleanTexture()
    {
        TextureBtn.Clear();
        nameOffices.Clear();
        listNameOffie.Clear();
        currentIndex = 0;
    }

    bool stillUpdatingLogo = false;
    string oldUpdate = "";
    int countDown = 0;

    public IEnumerator updateLogo()
    {
        stillUpdatingLogo = true;
        for (int i = 1; i <= NUMBER_FLOOR; i++)
        {
            StartCoroutine(updateIcon(IP + "src/b8" + i + "0" + imageType, "floor" + i + "_root"));
            yield return new WaitForSeconds(0.1F);
        }
        stillUpdatingLogo = false;
        yield return null;
    }
    string oldLanguage = null;
    public void changeLanguare(string language)
    {
        resetTimer();
        if (oldLanguage != language)
        {
            currentLanguage = language;
            dontAddhandi = true;
            isHandicapMode = !isHandicapMode;
            handicap = !handicap;
            GameObject.Find("handicap").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage + "handicap"];
            handicapMode();
            dontAddhandi = false;
            oldLanguage = language;
            if (currentLanguage == null || currentLanguage == "")
                floorOfficeOn.text = floorOfficeOn.text.Replace("Andar", "Floor");
            else floorOfficeOn.text = floorOfficeOn.text.Replace("Floor", "Andar");
        }
    }


    private IEnumerator updateIcon(string url, string nameobject)
    {
        //Debug.Log (url);

        GameObject plane = GameObject.Find(nameobject);

        var rend = plane.GetComponent<Renderer>();

        WWW www = new WWW(url);
        yield return www;
        rend.material.mainTexture = www.texture;
        countDown--;
    }

    Dictionary<string, Sprite> spriteSave = new Dictionary<string, Sprite>();
    Dictionary<string, string> DicphoneNumber = new Dictionary<string, string>();
    Dictionary<string, string> DicNumberOffice = new Dictionary<string, string>();
    Dictionary<string, string> listNameOffie = new Dictionary<string, string>();

    private IEnumerator loadTexture4Office(string name, string nameOffice, string phoneNumber, int index, string subNameOffice, string officeNumber)
    {
        //if (gameObject != null) 
        {
            Text texts = null;
            Button buttons = null;

            TextureBtn.Add(name);
            nameOffices.Add(nameOffice);
            if (subNameOffice != null)
            {
                listNameOffie.Add(name, subNameOffice);
            }
            else
            {
                listNameOffie.Add(name, nameOffice);
            }
            if (index < maxOffice)
            {

                GameObject.Find("p" + index).GetComponent<Image>().enabled = true;
                texts = GameObject.Find("of" + index).GetComponent<Text>();
                buttons = GameObject.Find("Btn" + index).GetComponent<Button>();
            }
            Sprite sprite;
            if (!spriteSave.ContainsKey(name))
            {
                /*GameObject gameobjects = GameObject.Find (name);
				Texture2D texture = (Texture2D)gameobjects.GetComponent<Renderer> ().material.mainTexture;*/

                /*string url = IP + "logo/" + name + imageType;
				Texture2D texture = null;
				WWW imageURLWWW = new WWW (url);		
				yield return imageURLWWW;		
				if (imageURLWWW.texture != null) {
					texture = imageURLWWW.texture;
				}*/

                string fullPathFile = "C:/server/logo/" + name + imageType;
                byte[] data = File.ReadAllBytes(fullPathFile);
                Texture2D texture = new Texture2D(87, 87, TextureFormat.ARGB32, false);
                texture.LoadImage(data);

                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                spriteSave.Add(name, sprite);
                //Debug.Log(name+":"+texture.width);
            }
            else
            {
                sprite = spriteSave[name];
            }
            if (!DicphoneNumber.ContainsKey(name))
            {
                DicphoneNumber.Add(name, phoneNumber);
            }
            if (!DicNumberOffice.ContainsKey(name))
            {
                DicNumberOffice.Add(name, officeNumber);
            }
            sprite.name = name;
            if (buttons != null && texts != null)
            {

                texts.enabled = true;
                texts.text = nameOffice;

                buttons.enabled = true;
                buttons.image.sprite = sprite;
                Color c = buttons.targetGraphic.color;
                c.a = 255f;
                buttons.targetGraphic.color = c;
            }
        }
        yield return null;
    }

    int maxEvent = 3, currentEvent = 0;
    Dictionary<string, events> eventInf = new Dictionary<string, events>();
    List<string> eventId = new List<string>();
    private IEnumerator loadTexture4Event(string id, string title, string dateTime, string description, int index)
    {
        //if (gameObject != null) 
        {
            //Debug.Log(title);
            Sprite sprite;
            if (!eventInf.ContainsKey(id))
            {
                eventId.Add(id);
                Texture2D texture = null;
                var url = IP + "event/" + id;
                //Debug.Log(url);
                WWW imageURLWWW = new WWW(url);
                yield return imageURLWWW;
                if (imageURLWWW.texture != null)
                {
                    texture = imageURLWWW.texture;
                }
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                eventInf.Add(id, new events(
                                           sprite,
                                           convertToUtf8(toNormalString(title)),
                                           convertToUtf8(toNormalString(dateTime)),
                                           convertToUtf8(toNormalString(description))));
            }
            else
            {
                sprite = eventInf[id].sprite;
            }


            if (index < maxEvent)
            {

                if (index == 0)
                {
                    evnt1.enabled = true;
                }
                else if (index == 1)
                {
                    evnt2.enabled = true;
                }
                else if (index == 2)
                {
                    evnt3.enabled = true;
                }

                GameObject.Find("maineventsImg" + (index + 1)).GetComponent<Image>().sprite = sprite;

                GameObject.Find("evntTitle" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(title));

                GameObject.Find("eventTime" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(dateTime));

                GameObject.Find("eventDescription" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(description));
                currentEvent++;
            }
        }
        yield return null;
    }

    int maxCinema = 6, currentCinema = 0;
    Dictionary<string, cinema> cinemaInf = new Dictionary<string, cinema>();
    List<string> cinemaId = new List<string>();
    private IEnumerator loadTexture4Cinema(string id, string title, string director, string list, string duration, string room, string schedule, string other, int index)
    {
        //if (gameObject != null) 
        {
            //Debug.Log(title);
            Sprite sprite;
            if (!cinemaInf.ContainsKey(id))
            {
                cinemaId.Add(id);
                Texture2D texture = null;
                var url = IP + "cinema/" + id;
                //Debug.Log(url);
                WWW imageURLWWW = new WWW(url);
                yield return imageURLWWW;
                if (imageURLWWW.texture != null)
                {
                    texture = imageURLWWW.texture;
                }
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                cinemaInf.Add(id, new cinema(sprite,
                                           convertToUtf8(toNormalString(title)),
                                           convertToUtf8(toNormalString(director)),
                                           convertToUtf8(toNormalString(list)),
                                           convertToUtf8(toNormalString(duration)),
                                           convertToUtf8(toNormalString(room)),
                                           convertToUtf8(toNormalString(schedule)),
                                           convertToUtf8(toNormalString(other))));
            }
            else
            {
                sprite = cinemaInf[id].sprite;
            }

            if (index < maxCinema)
            {

                GameObject.Find("cine" + (index + 1)).GetComponent<Canvas>().enabled = true;

                GameObject.Find("mainCineImg" + (index + 1)).GetComponent<Image>().sprite = sprite;
                GameObject.Find("cineTitle" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(title));
                GameObject.Find("cineDirector" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(director));
                GameObject.Find("cineList" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(list));
                GameObject.Find("cineDuration" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(duration));
                GameObject.Find("cineRoom" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(room));
                GameObject.Find("cineSchedules" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(schedule));
                GameObject.Find("cineOther" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(other));
                currentCinema++;
            }
        }
        yield return null;
    }

    int maxTheater = 6, currentTheater = 0;
    Dictionary<string, theater> theaterInf = new Dictionary<string, theater>();
    List<string> theaterId = new List<string>();
    private IEnumerator loadTexture4Theater(string id, string title, string genre, string classification, string schedules, string season, string other, int index)
    {
        //if (gameObject != null) 
        {
            //Debug.Log(title);
            Sprite sprite;
            if (!theaterInf.ContainsKey(id))
            {
                theaterId.Add(id);
                Texture2D texture = null;
                var url = IP + "theater/" + id;
                //Debug.Log(url);
                WWW imageURLWWW = new WWW(url);
                yield return imageURLWWW;
                if (imageURLWWW.texture != null)
                {
                    texture = imageURLWWW.texture;
                }
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                theaterInf.Add(id, new theater(sprite,
                                            convertToUtf8(toNormalString(title)),
                                            convertToUtf8(toNormalString(genre)),
                                            convertToUtf8(toNormalString(classification)),
                                            convertToUtf8(toNormalString(schedules)),
                                            convertToUtf8(toNormalString(season)),
                                            convertToUtf8(toNormalString(other))));
            }
            else
            {
                sprite = theaterInf[id].sprite;
            }

            if (index < maxTheater)
            {

                GameObject.Find("theater" + (index + 1)).GetComponent<Canvas>().enabled = true;

                GameObject.Find("mainTheaterImg" + (index + 1)).GetComponent<Image>().sprite = sprite;
                GameObject.Find("theaterTitle" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(title));
                GameObject.Find("theaterGenre" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(genre));
                GameObject.Find("theaterClassification" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(classification));
                GameObject.Find("theaterSchedules" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(schedules));
                GameObject.Find("theaterSeason" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(season));
                GameObject.Find("theaterOther" + (index + 1)).GetComponent<Text>().text = convertToUtf8(toNormalString(other));
                currentTheater++;
            }
        }
        yield return null;
    }

    string currentNameLayoutShow;

    public void segementSearchPress()
    {
        resetTimer();
        offset = 0;
        hideEventAndInfomation();
        exitvideo();
        hideOldeScreen();
        showFullTransparent();
        GameObject.Find("Panelcontainsegments").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
        currentNameLayoutShow = "Panelcontainsegments";
        updateArrow(true);
        StartCoroutine(loadTextureSegment(true));
    }

    bool isMaster = false;
    private IEnumerator loadTextureSegment(bool master)
    {
        string handi = null;
        isMaster = master;
        if (isHandicapMode)
            handi = "handi";

        {
            for (int i = 0; i < 15; i++)
            {
                Button btn = GameObject.Find("SG" + i).GetComponent<Button>();
                btn.enabled = true;
                Color c = btn.targetGraphic.color;
                c.a = 255f;
                btn.targetGraphic.color = c;
                btn.image.sprite = ResourcesDictionary[currentLanguage + segmentNameArray[i] + handi];
            }
        }
        yield return null;
    }

    public void nextSegment()
    {
        resetTimer();
        StartCoroutine(nextSgm());
    }

    public void previosSegment()
    {
        resetTimer();
        StartCoroutine(previSgm());
    }

    int offset = 0;

    private IEnumerator nextSgm()
    {
        if (offset >= 15)
            offset = 0;
        else
            offset += 15;

        {
            string handi = null;
            if (isHandicapMode)
                handi = "handi";
            for (int i = 0; i < 15; i++)
            {
                Button btn = GameObject.Find("SG" + i).GetComponent<Button>();
                if ((i + offset) < segmentNameArray.Length)
                {
                    btn.enabled = true;
                    Color c = btn.targetGraphic.color;
                    c.a = 255f;
                    btn.targetGraphic.color = c;
                    btn.image.sprite = ResourcesDictionary[currentLanguage + segmentNameArray[i + offset] + handi];
                }
                else
                {
                    Color c = btn.targetGraphic.color;
                    c.a = 0f;
                    btn.targetGraphic.color = c;
                    btn.enabled = false;
                }
            }
        }
        yield return null;
    }

    private IEnumerator previSgm()
    {
        if (offset == 0)
            offset = 15;
        else
            offset -= 15;

        {
            string handi = null;
            if (isHandicapMode)
                handi = "handi";
            for (int i = 0; i < 15; i++)
            {
                Button btn = GameObject.Find("SG" + i).GetComponent<Button>();
                if ((i + offset) < segmentNameArray.Length)
                {
                    btn.enabled = true;
                    Color c = btn.targetGraphic.color;
                    c.a = 255f;
                    btn.targetGraphic.color = c;
                    btn.image.sprite = ResourcesDictionary[currentLanguage + segmentNameArray[i + offset] + handi];
                }
                else
                {
                    Color c = btn.targetGraphic.color;
                    c.a = 0f;
                    btn.targetGraphic.color = c;
                    btn.enabled = false;
                }
            }
        }
        yield return null;
    }

    void hideOldeScreen()
    {

        if (currenNameLayoutMovie != null)
        {
            GameObject.Find(currenNameLayoutMovie).GetComponent<Animator>().SetBool(m_OpenMovieParameterId, false);
            //hideCinemaLayout ();
            showCarousel(true);
            closeTimer.Stop();
            currenNameLayoutMovie = null;
        }
        if (currentNameLayoutShow != null)
        {
            GameObject.Find(currentNameLayoutShow).GetComponent<Animator>().SetBool(m_OpenParameterId, false);
            currentNameLayoutShow = null;
        }
        hideEventLayout();

    }

    public void hideEventLayout()
    {
        evnt1.enabled = false;
        evnt2.enabled = false;
        evnt3.enabled = false;
    }

    public void hideCinemaLayout()
    {
        for (int i = 1; i <= maxCinema; i++)
        {
            GameObject.Find("cine" + i).GetComponent<Canvas>().enabled = false;
            GameObject.Find("theater" + i).GetComponent<Canvas>().enabled = false;
        }
    }

    public void EventPress()
    {
        //writetofile.append2File (buginfo, "\neventPress:");
        resetTimer();
        hideEventAndInfomation();
        if (currentNameLayoutShow != "Panelcontainevents")
        {
            currentEvent = 0;
            exitvideo();
            hideOldeScreen();
            showFullTransparent();
            int index = 0;
            foreach (string x in infomationEvents)
            {
                if (x != "")
                {
                    string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                    StartCoroutine(loadTexture4Event(info[0], info[1], info[2], info[3], index));
                    index++;
                }
            }
            GameObject.Find("Panelcontainevents").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
            currentNameLayoutShow = "Panelcontainevents";
        }

    }

    public void ClosePress()
    {
        //if(currentNameLayoutShow == "Panelcontainevents") 
        {
            resetTimer();
            hideOldeScreen();
            hideFullTransparent();
        }
    }

    public void nextEvent()
    {
        resetTimer();
        if (eventId.Count > maxEvent)
        {
            for (int i = 1; i <= maxEvent; i++)
            {
                if (currentEvent < eventId.Count)
                {

                    events evs = eventInf[eventId[currentEvent]];

                    GameObject.Find("maineventsImg" + i).GetComponent<Image>().sprite = evs.sprite;

                    GameObject.Find("evntTitle" + i).GetComponent<Text>().text = evs.title;

                    GameObject.Find("eventTime" + i).GetComponent<Text>().text = evs.dateTime;

                    GameObject.Find("eventDescription" + i).GetComponent<Text>().text = evs.description;

                    currentEvent++;
                    if (i == 1)
                    {
                        evnt1.enabled = true;
                    }
                    else if (i == 2)
                    {
                        evnt2.enabled = true;
                    }
                    else if (i == 3)
                    {
                        evnt3.enabled = true;
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        evnt1.enabled = false;
                    }
                    else if (i == 2)
                    {
                        evnt2.enabled = false;
                    }
                    else if (i == 3)
                    {
                        evnt3.enabled = false;
                    }
                }
            }
            if (currentEvent >= eventId.Count)
                currentEvent = 0;
        }
    }

    public void preEvent()
    {
        currentEvent = currentEvent - maxEvent;
        if (currentEvent < 0)
            currentEvent = ((int)(eventId.Count - 1) / maxEvent) * maxEvent;

        currentEvent = currentEvent - maxEvent;
        if (currentEvent < 0)
            currentEvent = ((int)(eventId.Count - 1) / maxEvent) * maxEvent;

        //Debug.Log (currentEvent);
        nextEvent();
    }

    public void nextCinema()
    {
        resetTimer();
        closeTimer.Stop();
        closeTimer.Start();
        if (currentCinema >= cinemaId.Count)
            currentCinema = 0;
        //Debug.Log (cinemaId.Count);
        if (cinemaId.Count > maxCinema)
        {
            //Debug.Log("currentCinema:"+currentCinema);
            for (int i = 1; i <= maxCinema; i++)
            {
                if (currentCinema < cinemaId.Count)
                {

                    cinema evs = cinemaInf[cinemaId[currentCinema]];
                    //Debug.Log("currentCinema:"+currentCinema+", index:"+i+", title:"+evs.title);

                    GameObject.Find("cine" + i).GetComponent<Canvas>().enabled = true;

                    GameObject.Find("mainCineImg" + i).GetComponent<Image>().sprite = evs.sprite;
                    GameObject.Find("cineTitle" + i).GetComponent<Text>().text = evs.title;
                    GameObject.Find("cineDirector" + i).GetComponent<Text>().text = evs.director;
                    GameObject.Find("cineList" + i).GetComponent<Text>().text = evs.list;
                    GameObject.Find("cineDuration" + i).GetComponent<Text>().text = evs.duration;
                    GameObject.Find("cineRoom" + i).GetComponent<Text>().text = evs.room;
                    GameObject.Find("cineSchedules" + i).GetComponent<Text>().text = evs.schedules;
                    GameObject.Find("cineOther" + i).GetComponent<Text>().text = evs.other;

                }
                else
                {
                    //Debug.Log("disable currentCinema:"+currentCinema+", index:"+i);
                    GameObject.Find("cine" + i).GetComponent<Canvas>().enabled = false;
                }
                currentCinema++;
            }
            if (currentCinema >= cinemaId.Count)
                currentCinema = 0;
        }
    }

    public void preCinema()
    {
        currentCinema = currentCinema - maxCinema;
        if (currentCinema < 0)
            currentCinema = ((int)(cinemaId.Count - 1) / maxCinema) * maxCinema;

        currentCinema = currentCinema - maxCinema;
        if (currentCinema < 0)
            currentCinema = ((int)(cinemaId.Count - 1) / maxCinema) * maxCinema;

        //Debug.Log (currentEvent);
        nextCinema();
    }


    public void nextTheater()
    {
        resetTimer();
        closeTimer.Stop();
        closeTimer.Start();
        if (currentTheater >= theaterId.Count)
            currentTheater = 0;
        //Debug.Log (cinemaId.Count);
        if (theaterId.Count > maxTheater)
        {
            //Debug.Log("currentCinema:"+currentCinema);
            for (int i = 1; i <= maxTheater; i++)
            {
                if (currentTheater < theaterId.Count)
                {

                    theater evs = theaterInf[theaterId[currentTheater]];
                    //Debug.Log("currentCinema:"+currentCinema+", index:"+i+", title:"+evs.title);

                    GameObject.Find("theater" + i).GetComponent<Canvas>().enabled = true;

                    GameObject.Find("mainTheaterImg" + i).GetComponent<Image>().sprite = evs.sprite;
                    GameObject.Find("theaterTitle" + i).GetComponent<Text>().text = evs.title;
                    GameObject.Find("theaterGenre" + i).GetComponent<Text>().text = evs.genre;
                    GameObject.Find("theaterClassification" + i).GetComponent<Text>().text = evs.classification;
                    GameObject.Find("theaterSchedules" + i).GetComponent<Text>().text = evs.schedules;
                    GameObject.Find("theaterSeason" + i).GetComponent<Text>().text = evs.season;
                    GameObject.Find("theaterOther" + i).GetComponent<Text>().text = evs.other;

                }
                else
                {
                    //Debug.Log("disable currentCinema:"+currentCinema+", index:"+i);
                    GameObject.Find("theater" + i).GetComponent<Canvas>().enabled = false;
                }
                currentTheater++;
            }
            if (currentTheater >= theaterId.Count)
                currentTheater = 0;
        }
    }

    public void preTheater()
    {
        currentTheater = currentTheater - maxTheater;
        if (currentTheater < 0)
            currentTheater = ((int)(theaterId.Count - 1) / maxTheater) * maxTheater;

        currentTheater = currentTheater - maxTheater;
        if (currentTheater < 0)
            currentTheater = ((int)(theaterId.Count - 1) / maxTheater) * maxTheater;

        //Debug.Log (currentEvent);
        nextTheater();
    }

    public void searchOfficeBySegment(int index)
    {
        resetTimer();
        string segement, nameOfContainPanel = "Panelcontainsegments";
        segement = segmentNameArray[index + offset];
        Debug.Log(offset + "," + segement);
        //log_debug = "\nsegment:"+segement;
        StartCoroutine(searchbySegement(segement, nameOfContainPanel));
    }

    private IEnumerator searchbySegement(string segement, string nameOfContainPanel)
    {
        bool haveResult = false;
        cleanTexture();
        foreach (string x in infomationForSearch)
        {
            if (x != "")
            {
                string[] info = x.Split(new string[] { " " }, System.StringSplitOptions.None);
                if ((isMaster && info[0].ToLower()[1] == '8') || (!isMaster && info[0].ToLower()[1] != '8'))
                {
                    if (info[3].ToLower() == segement && info[1] != "for_empty_office")
                    {
                        haveResult = true;
                        //log_debug += "\n"+string.Join(",",info);
                        StartCoroutine(loadTexture4Office(info[0], convertToUtf8(toNormalString(info[1])), toNormalString(info[4]), currentIndex, null, toNormalString(info[2])));
                        if (currentIndex < maxOffice)
                            currentIndex++;
                    }
                }
            }
        }

        GameObject.Find(nameOfContainPanel).GetComponent<Animator>().SetBool(m_OpenParameterId, false);

        if (haveResult)
        {
            GameObject.Find("PanelContainresults").GetComponent<Animator>().SetBool(m_OpenParameterId, true);
            currentNameLayoutShow = "PanelContainresults";
            cleanAllOffice(currentIndex);
        }
        else
            hideFullTransparent();
        yield return null;
    }

    bool isBathRoomSearch = false;

    public void bathRoomPress()
    {
        //writetofile.append2File (buginfo, "\nbathroomPress:");
        resetTimer();
        hideEventAndInfomation();
        exitvideo();
        hideOldeScreen();
        hideFullTransparent();
        isBathRoomSearch = true;
        //string blcName = "b8177";

        hideSearchBlock();

        stopRoute();

        hideBlck(currentBlock, currentFloor);

        int Block = 8;//int.Parse (blcName [1].ToString ());
        int Floor = 3;//int.Parse (blcName [2].ToString ());

        showBlck(Block, 3);
        listNameCurrentBlock.Add("block" + Block + "_3");
        currentBlock = Block;
        currentFloor = Floor;
        getRoute("office70");
        getRoute("office71");
    }

    public void next()
    {
        resetTimer();
        if (TextureBtn.Count > maxOffice)
        {
            for (int i = 0; i < maxOffice; i++)
            {
                if (currentIndex < TextureBtn.Count)
                {
                    //Debug.Log(currentIndex);
                    GameObject.Find("p" + i).GetComponent<Image>().enabled = true;

                    var t = GameObject.Find("of" + i).GetComponent<Text>();
                    t.enabled = true;
                    t.text = nameOffices[currentIndex];

                    Sprite sprite = spriteSave[TextureBtn[currentIndex]];
                    var plane = GameObject.Find("Btn" + i).GetComponent<Button>();
                    plane.enabled = true;
                    plane.image.sprite = sprite;
                    Color c = plane.targetGraphic.color;
                    c.a = 255f;
                    plane.targetGraphic.color = c;
                    currentIndex++;
                }
                else
                {

                    GameObject.Find("p" + i).GetComponent<Image>().enabled = false;

                    GameObject.Find("of" + i).GetComponent<Text>().enabled = false;

                    var plane = GameObject.Find("Btn" + i).GetComponent<Button>();
                    Color c = plane.targetGraphic.color;
                    c.a = 0f;
                    plane.targetGraphic.color = c;
                    plane.enabled = true;
                }
            }
            if (currentIndex >= TextureBtn.Count)
                currentIndex = 0;
        }
    }

    public int preIndex = 0;

    public void previous()
    {
        currentIndex = currentIndex - maxOffice;
        if (currentIndex < 0)
            currentIndex = ((int)TextureBtn.Count / maxOffice) * maxOffice;

        currentIndex = currentIndex - maxOffice;
        if (currentIndex < 0)
            currentIndex = ((int)TextureBtn.Count / maxOffice) * maxOffice;

        next();
    }

    private int m_OpenMovieParameterId;
    private int m_ShowEventParameterId;
    private int m_OpenParameterId;
    private int m_FullScreenParameterId;
    private int m_showScreenParameterId;
    private int m_showDirctionVideoId;
    private int m_showAnimationButtonPressed;
    private int m_showAnimationBlockPressed;
    const string k_showEventTransitionName = "ShowEvent";
    const string k_OpenMovieTransitionName = "movieOpen";
    const string k_OpenTransitionName = "Open";
    const string k_FullScreenTransitionName = "FullScreen";
    const string k_showScreenTransitionName = "Show";
    const string k_showDirctionVideoTransitionName = "ShowVideoDirction";
    const string k_buttonPressTransitionName = "Pressed";
    const string k_buttonBlockPressTransitionName = "BlockClick";

    public void typeButton(string chara)
    {
        resetTimer();
        StartCoroutine(typeButtonAni(chara));
    }

    public IEnumerator typeButtonAni(string name)
    {
        //GameObject.Find ("Panelcontainkey").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
        //yield return new WaitForSeconds(1F);
        string texxx = officeFliter.text;
        if (name == "backspace")
        {
            if (texxx.Length > 0)
                officeFliter.text = texxx.Substring(0, texxx.Length - 1);
        }
        else
        {
            officeFliter.text = texxx + name;
        }
        if (officeFliter.text.Length > 2)
        {
            //log_debug = "\nkeyboard:"+officeFliter.text;
            StartCoroutine(searchOffice(officeFliter.text));
        }
        else if (keycurrentIndex > 0)
        {
            Debug.Log("clear all office in fliter!!");
            StartCoroutine(clearallFliter());
        }

        yield return null;
    }

    public IEnumerator clearallFliter()
    {
        yield return new WaitForSeconds(0.5F);
        keycurrentIndex = 0;
        KeycleanAllOffice(keycurrentIndex);
    }

    int currentCarousel = 0, timeDisplay = -100;
    bool shownextCarousel = false, firstLoadCarousel = true;

    Dictionary<string, Texture> dicImageCarousel = new Dictionary<string, Texture>();


    MovieTexture movieTextureCarousel;

    private IEnumerator loadNextVideo()
    {

        string[] infos = infomationCarousel[currentCarousel].Split(new string[] { " " }, System.StringSplitOptions.None);
        string filename = infos[0];
        int timeDisplay = int.Parse(infos[1]);

        if (timeDisplay <= 0)
        {

            WWW www = new WWW(IP + "crs/" + filename);

            while (!www.isDone) yield return 1;

            if (www.bytes.Length > 0)
            {
                string fullPath = fullPathVideoFolder + "crs/" + filename;
                Debug.Log(fullPath + "finished download!!!");
                File.WriteAllBytes(fullPath, www.bytes);
            }

        }
    }


    private IEnumerator loadcrosel()
    {

        if (infomationCarousel[currentCarousel] != "" && infomationCarousel[currentCarousel] != null)
        {
            carouselTimer.Stop();
            string[] infos = infomationCarousel[currentCarousel].Split(new string[] { " " }, System.StringSplitOptions.None);
            string filename = infos[0];
            timeDisplay = int.Parse(infos[1]);
            //Debug.Log(filename+timeDisplay);
            if (timeDisplay > 0)
            {
                var url = IP + "crs/" + filename;
                Texture imageTexture = null;

                if (!dicImageCarousel.ContainsKey(url))
                {

                    //Debug.Log("down car");

                    WWW imageURLWWW = new WWW(url);
                    yield return imageURLWWW;
                    if (imageURLWWW.texture != null)
                    {
                        imageTexture = (Texture)imageURLWWW.texture;
                    }
                    dicImageCarousel.Add(url, imageTexture);
                }
                else
                {
                    //Debug.Log("use old car");
                    imageTexture = dicImageCarousel[url];
                }
                movieCrsPlayer.UnloadMovie();
                Videocarosel.texture = imageTexture;
                carouselTimer.Interval = timeDisplay * 1000;
                carouselTimer.Start();
            }
            else
            {
                if (Videocarosel.texture != null)
                    Videocarosel.texture = null;
                /*if(haveNextData){
					haveNextData = false;
				}else {
					/*
					var url = IP + "crs/" + filename;					
					//Debug.Log (url);					
					
					WWW www = new WWW(url);
					
					while(!www.isDone) yield return 1;
					
					if (www.bytes.Length > 0) 
					{						
						string fullPath = fullPathVideoFolder + "/" + filename;
						File.WriteAllBytes (fullPath, www.bytes);
					}
				}*/
                //Debug.Log(fullPathVideoFolder + filename);
                carouselTimer.Interval = movieCrsPlayer.playVideoFromFile(fullPathVideoFolder + "crs/" + filename) * 1000;
                carouselTimer.Start();
            }
        }
        else
        {
            if (infomationCarousel.Length > 1)
                shownextCarousel = true;
        }
        currentCarousel++;
        currentCarousel = currentCarousel % (infomationCarousel.Length - 1);
        //StartCoroutine (loadNextVideo ());
        yield return null;
    }
    MovieTexture movieTextureStairDown;
    MovieTexture movieTextureElevatorDown;

    MovieTexture movieTextureDirctionStair;
    MovieTexture movieTextureDirctionElevator;
    private IEnumerator loadVideoFromResources()
    {

        movieTextureDirctionElevator = Resources.Load<MovieTexture>("ElevatorUp");
        while (!movieTextureDirctionElevator.isReadyToPlay)
        {
            yield return null;
        }
        movieTextureDirctionElevator.loop = true;
        movieTextureDirctionElevator.Stop();

        movieTextureStairDown = Resources.Load<MovieTexture>("StairDown");
        while (!movieTextureStairDown.isReadyToPlay)
        {
            yield return null;
        }
        movieTextureStairDown.loop = true;
        movieTextureStairDown.Stop();

        movieTextureElevatorDown = Resources.Load<MovieTexture>("ElevatorDown");
        while (!movieTextureElevatorDown.isReadyToPlay)
        {
            yield return null;
        }
        movieTextureElevatorDown.loop = true;
        movieTextureElevatorDown.Stop();

        movieTextureDirctionStair = (MovieTexture)VideoDirection.texture;
        movieTextureDirctionStair.loop = true;
        movieTextureDirctionStair.Stop();

        yield return null;
    }

    private IEnumerator loadAllResources()
    {

        foreach (string name in nameOfAllResource)
        {
            //if(Resources.Load<Sprite>(name)!=null)
            ResourcesDictionary.Add(name, Resources.Load<Sprite>(name));
            //else Debug.Log(name);
        }

        yield return null;
    }

    void zoomcamera(float deltaMagnitudeDiff)
    {
        // If the camera is orthographic...
        if (Camera.main.orthographic)
        {
            // ... change the orthographic size based on the change in distance between the touches.
            Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Make sure the orthographic size never drops below zero.
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
        }
        else
        {
            // Otherwise change the field of view based on the change in distance between the touches.
            Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 0 and 180.
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
        }
    }

    public void zoomin()
    {
        //zoomcamera (4);
        if (Camera.main.fieldOfView > 5)
            Camera.main.fieldOfView = Camera.main.fieldOfView - 5;
    }

    public void zoomout()
    {
        if (Camera.main.fieldOfView < 100)
            Camera.main.fieldOfView = Camera.main.fieldOfView + 5;
    }

    public float TargetFOV = 10f;

    Quaternion lastRotate;

    public float distance = 3f;
    float deltad = 0f;
    bool startPoint = false;

    void create_vessel(Vector3 p1, Vector3 p2, int index)
    {

        if (arrow == null)
        {
            arrow = GameObject.Find("arrow");
            if (arrow == null)
            {
                arrow = Instantiate(Resources.Load("arrow", typeof(GameObject))) as GameObject;
                arrow.name = "arrow";
            }
        }

        if (Cylinder == null)
        {
            Cylinder = GameObject.Find("lineorginal");
            if (Cylinder == null)
            {
                Cylinder = Instantiate(Resources.Load("lineorginal", typeof(GameObject))) as GameObject;
                Cylinder.name = "lineorginal";
            }
        }

        float d = Vector3.Distance(p1, p2);
        Vector3 v = p2 - p1;
        int num = (int)((d + deltad) / distance);
        for (int i = 1; i <= num; i++)
        {

            Vector3 start = p1 + ((i * distance - deltad) / d) * v;

            GameObject ar = GameObject.Instantiate(arrow) as GameObject;
            ar.name = "ball";
            arrow scri = ar.GetComponent<arrow>();
            scri.beginMove(listpoint, start, index);
            if (startPoint)
            {
                scri.thisIsStartPoint();
                startPoint = false;
            }

        }
        deltad = (d + deltad) - num * distance;


        Vector3 pos = Vector3.Lerp(p1, p2, (float)0.5);
        GameObject segObj = GameObject.Instantiate(Cylinder) as GameObject;
        segObj.name = "lineDirection";
        Vector3 newScale = segObj.transform.localScale;
        newScale.y = (Vector3.Distance(p1, p2) * 1.842288f) / 3.693893f;
        newScale.x = 0.1051401f;
        newScale.z = 0.1051401f;
        segObj.transform.localScale = newScale;
        segObj.transform.position = pos;
        segObj.transform.up = p2 - p1;
    }

    bool uppress = false, downpress = false, leftpress = false, rightpress = false;
    public void uppressed(BaseEventData eventData)
    {
        uppress = true;
    }
    public void upnotpressed(BaseEventData eventData)
    {
        uppress = false;
    }

    public void downpressed(BaseEventData eventData)
    {
        downpress = true;
    }
    public void downotpressed(BaseEventData eventData)
    {
        downpress = false;
    }

    public void leftpressed(BaseEventData eventData)
    {
        leftpress = true;
    }
    public void leftnotpressed(BaseEventData eventData)
    {
        leftpress = false;
    }

    public void rightpressed(BaseEventData eventData)
    {
        rightpress = true;
    }
    public void rightnotpressed(BaseEventData eventData)
    {
        rightpress = false;
    }
    public float transitionDuration = 3.0f;

    bool havenewcameraanimation = false, stillanimation = false;


    IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, Vector3 lookat)
    {
        fullScreenTimer.Stop();
        hideInfomationTimer.Stop();
        bool hncmr = false;
        if (havenextcamera)//|| havethirdcamera) 
        {
            hncmr = true;
            //Debug.Log("hhhhhhhhhhh");
        }
        if (stillanimation)
            havenewcameraanimation = true;
        while (havenewcameraanimation)
        {
            yield return null;
        }
        stillanimation = true;

        float t = 0.0f;
        Vector3 startingPos = Camera.main.transform.position;
        while (t < 1.0f && !havenewcameraanimation)
        {
            t += Time.deltaTime * (Time.timeScale / lerpSpeed);

            var targetRotation = Quaternion.LookRotation(lookat - Camera.main.transform.position, Vector3.up);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, t);

            yield return null;

        }
        t = 0.0f;
        while (t < 1.0f && !havenewcameraanimation)
        {
            t += Time.deltaTime * (Time.timeScale / lerpSpeed);

            Camera.main.transform.position = Vector3.Lerp(startingPos, newPosition, t);
            Camera.main.transform.LookAt(lookat);

            yield return null;
        }
        if (haveShowVideoDirection)
        {
            hideVideoDirection(true);
            //hideInfomationTimer.Stop();
            //hideInfomationTimer.Start();
            //Debug.Log("start time");
        }
        if (hncmr)
        {
            moveNextCamera.Start();
            //if(!havethirdcamera)
            {
                havenextcamera = false;
                if (stillShowVideoDirection)
                    haveShowVideoDirection = true;
            }
        }
        havenewcameraanimation = false;
        stillanimation = false;
        resetTimer();
        if (humanPress)
            hideInfomationTimer.Start();
        humanPress = true;
        yield return null;
    }

    public void hideEventAndInfomation()
    {
        GameObject.Find("containBlockInfomation").GetComponent<Animator>().SetBool(m_showScreenParameterId, false);
        reservedBtn.GetComponent<Animator>().SetBool(m_ShowEventParameterId, false);
    }


    IEnumerator updateTimeLable()
    {
        showTime.text = System.DateTime.Now.ToString("HH:mm:ss");
        yield return null;
    }

    private IEnumerator Wait(System.Action callback)
    {
        //while(movieTextureCarousel.isPlaying)
        //yield return new WaitForSeconds(0.1F);//for 32bit
        yield return new WaitForSeconds(1.0F);//for 64bit
        if (callback != null) callback();
    }

    private IEnumerator playOfficeVideo()
    {
        //yield return new WaitForSeconds(0.1F);
        isShowVideo(true);
        yield return null;
    }

    string buginfo = "building_Data\\bug.txt";
    string cameraangle = "building_Data\\data\\camereangle.txt";
    string pointPostions = "building_Data\\data\\points.txt";
    string officePostion = "building_Data\\data\\officePostion.txt";
    string linepostion = "building_Data\\data\\line.txt";
    string result = "", resultPostion = "", frontPoints = "";
    int index = 1, blckk = 7, flor = 1;
    string nameCameraPostion;

    void resetTimer()
    {
        fullScreenTimer.Stop();
        fullScreenTimer.Start();
    }

    public string toNormalString(string input)
    {
        return input.Replace("|enter|", System.Environment.NewLine).Replace("|space|", " ").Replace("|dotdot|", ":");
    }

    int indexOffice = 1;
    public void getPostionOfRoute(GameObject g)
    {
        Vector3 p = g.transform.position - GameObject.Find("block8_3").transform.position;

        result = "static Vector3 of" + indexOffice + " = new Vector3 (" + p.x + "F, 1.5F, " + p.z + "F);\n";

        writetofile.append2File(pointPostions, result);
        indexOffice++;
    }

    bool humanPress = false;

    void Update()
    {

        if (isStopApplication)
        {

            Debug.Log("stop");

        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {
                //arroundLeft ();
                Debug.Log("reset!!");
                if (isShowFullScreen)
                {
                    changeStatusScreen = true;
                    isShowFullScreen = false;
                    fullScreenTimer.Stop();
                }
                else resetTimer();
            }
            else if (rightpress || Input.GetKey(KeyCode.D))
            {
                arroundRight();
            }
            else if (uppress || Input.GetKey(KeyCode.W))
            {
                arroundUp();
            }
            else if (downpress || Input.GetKey(KeyCode.S))
            {
                arroundDown();
            }

            //if (!stillanimation) 
            {
                if (Input.touchCount > 0)
                {

                    if (isShowFullScreen)
                    {
                        changeStatusScreen = true;
                        isShowFullScreen = false;
                        fullScreenTimer.Stop();
                    }
                    else resetTimer();

                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        // Get movement of the finger since last frame
                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                        if (touchDeltaPosition.x < 0)
                        {
                            arroundRight();
                        }
                        else if (touchDeltaPosition.x > 0)
                        {
                            arroundLeft();
                        }
                    }
                }
            }

            if (update)
            {

                //StartCoroutine (sysServer ());
                update = false;
            }
            if (shownextCarousel)
            {
                shownextCarousel = false;
                StartCoroutine(loadcrosel());
            }

            /*
			if (Input.GetKey (KeyCode.Z)) {
				Vector3 p = Camera.main.transform.position;
				result += p.ToString () + ";";

				result += "\nstatic Vector3 " + currentBlock + "_" + currentFloor + "lookat" + nameCameraPostion + " = new Vector3 " + target.ToString () + ";";

				writetofile.append2File (cameraangle, result);
				result = "";
			}
		/*
			if (Input.GetKey (KeyCode.X)) {

				Vector3 p = GameObject.Find ("block8_1").transform.position;
				//Debug.Log(startAnimation.transform.position-p);

				for (int i = 1; i<231; i++) {
					GameObject x = GameObject.Find ("b81" + i);
					if (x != null) {					
						resultPostion += "\nstatic Vector3 f" + i + " = new Vector3 " + (x.transform.position - p).ToString () + ";";
					}
				}
				writetofile.append2File (pointPostions, resultPostion);
				resultPostion = "";*/
            /*
        Vector3 p = cube.transform.position - GameObject.Find("block8_3").transform.position;
        resultPostion ="\nstatic Vector3 p"+index+" = new Vector3 "+ p.ToString () + ";";
        writetofile.append2File(pointPostions,resultPostion);
        index++;
        resultPostion="";

*/
            /*
        string line;
        string re = "";

        // Read the file and display it line by line.
        Vector3 p = -GameObject.Find("block8_3").transform.position;// - GameObject.Find("block9_1").transform.position;
        System.IO.StreamReader file = 
            new System.IO.StreamReader("C:\\Users\\Nguyen Phong\\Downloads\\unity\\test2\\building_Data\\data\\points.txt");
        while((line = file.ReadLine()) != null)
        {
            int begin = line.IndexOf("(");
            if(begin>0){
                int end = line.IndexOf(")");
                string v = line.Substring(0,begin);
                string li = line.Substring(begin+1,end-begin-1);
                string[] vector = li.Split(new string[]{"F"},System.StringSplitOptions.None);
                Vector3 newP = new Vector3(float.Parse(vector[0]),float.Parse(vector[1]),float.Parse(vector[2]))+ p;
                re+=v+newP+";\n";
            }
        }

        file.Close();
        writetofile.write2File("C:\\Users\\Nguyen Phong\\Downloads\\unity\\test2\\building_Data\\data\\re.txt",re);*/
            //}
            /*
			if (Input.GetKey (KeyCode.C)) {
				float delta = 4.31f;
				for (int i = 1; i<67; i++) {
					GameObject x = GameObject.Find ("b" + blckk + flor + i);
					if (x != null) {
						Vector3 p = x.transform.position - GameObject.Find ("block" + blckk + "_" + flor).transform.position;
						resultPostion += "\nstatic Vector3 o" + i + " = new Vector3 " + p.ToString () + ";";

						if ((i > 0 && i < 6) || (i > 22 && i < 28) || (i == 44 || i == 59)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (0, 0, delta)).ToString () + ";";
						} else if ((i > 6 && i < 11) || (i > 28 && i < 33)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (-delta, 0, 0)).ToString () + ";";
						} else if ((i > 10 && i < 17) || (i > 33 && i < 39)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (0, 0, -delta)).ToString () + ";";
						} else if ((i > 17 && i < 22) || (i > 39 && i < 44) || (i > 54 && i < 59)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (delta, 0, 0)).ToString () + ";";
						}
					}
				}
				writetofile.append2File (officePostion, resultPostion);
				writetofile.append2File (pointPostions, frontPoints);
			}
*/
            /*
			if (Input.GetKey (KeyCode.L)) {
				Camera.main.transform.LookAt (target);
				Camera.main.transform.Translate (Camera.main.transform.forward * 0.75f);
			} else if (Input.GetKey (KeyCode.P)) {
				Camera.main.transform.LookAt (target);
				Camera.main.transform.Translate (Camera.main.transform.forward * -0.75f);
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				target += new Vector3 (-4f * Time.deltaTime, 0, 0);
				Camera.main.transform.Translate (new Vector3 (4f * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				target += new Vector3 (4f * Time.deltaTime, 0, 0);
				Camera.main.transform.Translate (new Vector3 (-4f * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				target += new Vector3 (0, -4f * Time.deltaTime, 0);
				Camera.main.transform.Translate (new Vector3 (0, -4f * Time.deltaTime, 0));
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				target += new Vector3 (0, 4 * Time.deltaTime, 0);
				Camera.main.transform.Translate (new Vector3 (0, 4 * Time.deltaTime, 0));
			}
			*/
            if (beginmovetonextcamera)
            {
                beginmovetonextcamera = false;
                /*if(havethirdcamera){
					havethirdcamera = false;
					setCamera(thirdCameraPostion,thirdCameraLookat);
				}
				else*/
                setCamera(posss, lattt);
            }

            if (isShowTime)
            {
                isShowTime = false;
                StartCoroutine(updateTimeLable());
            }

            if (changeStatusScreen)
            {
                ClosePress();
                changeStatusScreen = false;
                GameObject.Find("RawImageCrs").GetComponent<Animator>().SetBool(m_FullScreenParameterId, isShowFullScreen);
                if (isShowFullScreen)
                {
                    fullScreenVideoCrs();
                    fullScreenTimer.Stop();
                }
                else
                {
                    fullScreenTimer.Start();
                    resetVideoCrs();
                }
            }
            if (isHideInfomation)
            {
                humanPress = false;
                hideEventAndInfomation();
                isHideInfomation = false;
                hideInfomationTimer.Stop();
                gotoFloor(3);
                //Debug.Log("show Initial");
            }
            if (isCloseCinema)
            {
                isCloseCinema = false;
                ClosePress();
                closeTimer.Stop();
            }
        }
    }
}

