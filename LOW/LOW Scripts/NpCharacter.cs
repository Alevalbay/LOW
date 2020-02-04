using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpCharacter : MonoBehaviour
{
    public TMP_Text npcName;
    public GameObject head;
    public GameObject chest;
    public GameObject lArm;
    public GameObject rArm;
    public Color tempColor;
    public int npcHeight;
    public int npcWeight;
    //Kid  or Adult (kid 0 adult 1)
    public bool bodyType;
    public float hwRate;
    public int strenght;
    public int agility;
    public int intelligence;
    //List of NPC Traits
    public List<string> npcTraists = new List<string>();

    public string Job;




    void Start()
    {

        NpcGenerator();

    }

    void Update()
    {

    }

    //Npc Generator
    private void NpcGenerator()
    {
        NpcBodyType();
        NpcColorGenerator();
        NameGenerator();
        NpcHeightGenerator();
        NpcWeightGenerator();
        AlliginHeightAndWeight();
        SAI_Generator();
        TraitGenerator();
        
       
    }



    private void NpcBodyType()
    {

        if (gameObject.tag=="ChildNpc")
            bodyType = false;
       
        else
            bodyType = true;

        Debug.Log("BodyType Belirlendi" + bodyType);

    }

    //Npc Color Generator
    private void NpcColorGenerator()
    {
        for (int i = 0; i < 3; i++)
        {
            tempColor = GenerateColor();
            switch (i)
            {
                case 0:
                    //Head Color
                    head.GetComponent<Renderer>().material.color = tempColor;
                    break;

                case 1:
                    //Chest Color
                    chest.GetComponent<Renderer>().material.color = tempColor;
                    break;
                case 2:
                    //arms Color
                    lArm.GetComponent<Renderer>().material.color = tempColor;
                    rArm.GetComponent<Renderer>().material.color = tempColor;
                    break;
            }

        }

    }


    //Random Color Function
    private Color GenerateColor()
    {
        Color randomColor;
        randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        return randomColor;
    }

    //Random Name Generator Function
    private void NameGenerator()
    {
        List<string> names = new List<string>{"Joel Cole","Kaleb Fraser","Carson Bates","Danny Foster","Kaiden Powell","Zakaria Jenkins","Ashton Hart","Tommy Powell","Kingsley Spencer"," Jaden Davies","Skyler Howard","Nicky Harper","Leslie Shaw","Clem Powell","Justice Lowe","Leigh Berry","Jordan Ross","Aubrey Davis","Fran Fox","Ralphie Collins","Jude Robinson","Skye Green","Raylee Harvey","Carmen George","Charlie Jackson","Tanner Porter","Carol Davies","Mel Lee","Leigh Fletcher","Gabe May","Bailey Phillips","Sidney Read","Emerson Spencer","Ali Gill","Blair Bell","Taylor Dixon","Franky Turner","Dane Moss","Clem Mitchell","Tyler Palmer","Mell Henderson","Billy Lewis","Aaren Campbell","Hayden Williamson","Lee Carter","Angel Brooks","River Ross","Sidney Wood","Jackie Hunter","Danny Wells","Carmen Barker","Lesley Walsh","Vic Gray","Aiden Thomas","Lee Thomas","Kris Powell","Gene Stewart","Kai Burton","Harper Thomson","Glenn Hunt","Quinn Mason","Aaren Pearce","Bennie White","Franky Poole","Hayden Murphy","Avery Jackson","Danny Berry","Skyler Reid","Silver Robertson","Jude Hart","Lane Jenkins","Val Evans","Avery Wood","Skye Cook","Gabe Wright","Ash Robertson","Tanner Hawkins","Lesley Simpson","Fran Simpson","Aiden Wallace","Caden Kennedy","Dane Marsh","Danny Mason","Ali Miller","Logan Atkinson","Terry Doyle","Leslie Bell","Jody Hunt","Kris Cox","Danny Thomson"

        };
       
        string randomName;

        int r = Random.Range(0, names.Count);
        randomName = names[r];
        npcName.text = randomName;
        gameObject.name = ("NPC "+randomName);
    }

    //Generates Height (for kids 60-150,for adult 150-200)
    private void NpcHeightGenerator()
    {
        int minHeight;
        int maxHeight;

        if(bodyType==false)
        {
            minHeight = 100;
            maxHeight = 120;
        }
        else
        {
            minHeight = 180;
            maxHeight = 200;
        }

        //Generates random Height
        int randomHeight = Random.Range(minHeight, maxHeight);
        npcHeight = randomHeight;

    }
    //Generates Weight Function (for kid 10-60,for adult 60-120)
    private void NpcWeightGenerator()
    {
        int minWeight ;
        int maxWeight ;

        if(bodyType==false)
        {
            minWeight = 30;
            maxWeight = 40;
        }

        else
        {
            minWeight = 50;
            maxWeight = 90;
        }

        //Generates random weight
        npcWeight = Random.Range(minWeight, maxWeight);
    }
    //Function for alling Prefab Height
    private void AlliginHeightAndWeight()
    {
        //If npc is a kid hw rate factor will decrease 
        int factor;
        if (bodyType == false)
            factor = 32;
        else
            factor = 12;



        //Calculate height weight rate
        hwRate = (npcWeight / ((npcHeight/100f) * (npcHeight/100f)));
        // we dived 15 for game engine balance
        gameObject.transform.localScale= new Vector3(1f * hwRate / factor, 1f * hwRate / factor, 1f * hwRate / factor);
    }

    private void SAI_Generator()
    {
        int totalStats;
        if (bodyType == true)
            totalStats = 15;
        else
            totalStats = 5;
           
        
        for (int i=0; i<totalStats;i++)
        {
            int r = Random.Range(1, 4);

            switch (r)
            {
                case 1:
                    strenght++;
                    break;
                case 2:
                    agility++;
                    break;
                case 3:
                    intelligence++;
                    break;
            }
        }
    }

    private void TraitGenerator()
    {
        //234 Good Traits
        List<string> positiveTraits = new List<string>{"Accessible","Active","Adaptable","Admirable","Adventurous","Agreeable","Alert","Allocentric","Amiable","Anticipative","Appreciative","Articulate","Aspiring","Athletic","Attractive","Balanced","Benevolent","Brilliant","Calm","Capable","Captivating","Caring","Challenging","Charismatic","Charming","Cheerful","Clean","Clear-headed","Clever","Colorful","Companionly","Compassionate","Conciliatory","Confident","Conscientious","Considerate","Constant","Contemplative","Cooperative","Courageous","Courteous","Creative","Cultured","Curious","Daring","Debonair","Decent","Decisive","Dedicated","Deep","Dignified","Directed","Disciplined","Discreet","Dramatic","Dutiful","Dynamic","Earnest","Ebullient","Educated","Efficient","Elegant","Eloquent","Empathetic","Energetic","Enthusiastic","Esthetic","Exciting","Extraordinary","Fair","Faithful","Farsighted","Felicific","Firm","Flexible","Focused","Forecful","Forgiving","Forthright","Freethinking","Friendly","Fun-loving","Gallant","Generous","Gentle","Genuine","Good-natured","Gracious","Hardworking","Healthy","Hearty","Helpful","Herioc","High-minded","Honest","Honorable","Humble","Humorous","Idealistic","Imaginative","Impressive","Incisive","Incorruptible","Independent","Individualistic","Innovative","Inoffensive","Insightful","Insouciant","Intelligent","Intuitive","Invulnerable","Kind","Knowledge","Leaderly","Leisurely","Liberal","Logical","Lovable","Loyal","Lyrical","Magnanimous","Many-sided","Masculine  (Manly)","Mature","Methodical", "Maticulous", "Moderate", "Modest", "Multi -leveled", "Neat", "Nonauthoritarian", "Objective", "Observant", "Open", "Optimistic", "Orderly", "Organized", "Original", "Painstaking", "Passionate", "Patient", "Patriotic", "Peaceful", "Perceptive", "Perfectionist", "Personable", "Persuasive", "Planful", "Playful", "Polished", "Popular", "Practical", "Precise", "Principled", "Profound", "Protean", "Protective", "Providential", "Prudent", "Punctual", "Pruposeful", "Rational", "Realistic", "Reflective", "Relaxed", "Reliable", "Resourceful", "Respectful", "Responsible", "Responsive", "Reverential", "Romantic", "Rustic", "Sage", "Sane", "Scholarly", "Scrupulous", "Secure", "Selfless", "Self -critical", "Self -defacing", "Self -denying", "Self -reliant", "Self -sufficent", "Sensitive", "Sentimental", "Seraphic", "Serious", "Sexy", "Sharing", "Shrewd", "Simple", "Skillful", "Sober", "Sociable", "Solid", "Sophisticated", "Spontaneous", "Sporting", "Stable", "Steadfast", "Steady", "Stoic", "Strong", "Studious", "Suave", "Subtle", "Sweet", "Sympathetic", "Systematic", "Tasteful", "Teacherly", "Thorough", "Tidy", "Tolerant", "Tractable", "Trusting", "Uncomplaining", "Understanding", "Undogmatic", "Unfoolable", "Upright", "Urbane", "Venturesome", "Vivacious", "Warm", "Well -bred", "Well -read", "Well -rounded", "Winning", "Wise", "Witty", "Youthful" };
        //112 Netural Traits
        List<string> neturalTraits = new List<string> {"Absentminded","Aggressive","Ambitious","Amusing","Artful","Ascetic","Authoritarian","Big-thinking","Boyish","Breezy","Businesslike","Busy","Casual","Crebral","Chummy","Circumspect","Competitive","Complex","Confidential","Conservative","Contradictory","Crisp","Cute","Deceptive","Determined","Dominating","Dreamy","Driving","Droll","Dry","Earthy","Effeminate","Emotional","Enigmatic","Experimental","Familial","Folksy","Formal","Freewheeling","Frugal","Glamorous","Guileless","High-spirited","Huried","Hypnotic","Iconoclastic","Idiosyncratic","Impassive","Impersonal","Impressionable","Intense","Invisible","Irreligious","Irreverent","Maternal","Mellow","Modern","Moralistic","Mystical","Neutral","Noncommittal","Noncompetitive","Obedient","Old-fashined","Ordinary","Outspoken","Paternalistic","Physical","Placid","Political","Predictable","Preoccupied","Private","Progressive","Proud","Pure","Questioning","Quiet","Religious","Reserved","Restrained","Retiring","Sarcastic","Self-conscious","Sensual","Skeptical","Smooth","Soft","Solemn","Solitary","Stern","Stoiid","Strict","Stubborn","Stylish","Subjective","Surprising","Soft","Tough","Unaggressive","Unambitious","Unceremonious","Unchanging","Undemanding","Unfathomable","Unhurried","Uninhibited","Unpatriotic","Unpredicatable","Unreligious","Unsentimental","Whimsical" };
        //292 Negative Traits
        List<string> negativeTraits = new List<string> {"Abrasive","Abrupt","Agonizing","Aimless","Airy","Aloof","Amoral","Angry","Anxious","Apathetic","Arbitrary","Argumentative","Arrogantt","Artificial","Asocial","Assertive","Astigmatic","Barbaric","Bewildered","Bizarre","Bland","Blunt","Biosterous","Brittle","Brutal","Calculating","Callous","Cantakerous","Careless","Cautious","Charmless","Childish","Clumsy","Coarse","Cold","Colorless","Complacent","Complaintive","Compulsive","Conceited","Condemnatory","Conformist","Confused","Contemptible","Conventional","Cowardly","Crafty","Crass","Crazy","Criminal","Critical","Crude","Cruel","Cynical","Decadent","Deceitful","Delicate","Demanding","Dependent","Desperate","Destructive","Devious","Difficult","Dirty","Disconcerting","Discontented","Discouraging","Discourteous","Dishonest","Disloyal","Disobedient","Disorderly","Disorganized","Disputatious","Disrespectful","Disruptive","Dissolute","Dissonant","Distractible","Disturbing","Dogmatic","Domineering","Dull","Easily Discouraged","Egocentric","Enervated","Envious","Erratic","Escapist","Excitable","Expedient","Extravagant","Extreme","Faithless","False","Fanatical","Fanciful","Fatalistic","Fawning","Fearful","Fickle","Fiery","Fixed","Flamboyant","Foolish","Forgetful","Fraudulent","Frightening","Frivolous","Gloomy","Graceless","Grand","Greedy","Grim","Gullible","Hateful","Haughty","Hedonistic","Hesitant","Hidebound","High-handed","Hostile","Ignorant","Imitative","Impatient","Impractical","Imprudent","Impulsive","Inconsiderate","Incurious","Indecisive","Indulgent","Inert","Inhibited","Insecure","Insensitive","Insincere","Insulting","Intolerant","Irascible","Irrational","Irresponsible","Irritable","Lazy","Libidinous","Loquacious","Malicious","Mannered","Mannerless","Mawkish","Mealymouthed","Mechanical","Meddlesome","Melancholic","Meretricious","Messy","Miserable","Miserly","Misguided","Mistaken","Money-minded","Monstrous","Moody","Morbid","Muddle-headed","Naive","Narcissistic","Narrow","Narrow-minded","Natty","Negativistic","Neglectful","Neurotic","Nihilistic","Obnoxious","Obsessive","Obvious","Odd","Offhand","One-dimensional","One-sided","Opinionated","Opportunistic","Oppressed","Outrageous","Overimaginative","Paranoid","Passive","Pedantic","Perverse","Petty","Pharissical","Phlegmatic","Plodding","Pompous","Possessive","Power-hungry","Predatory","Prejudiced","Presumptuous","Pretentious","Prim","Procrastinating","Profligate","Provocative","Pugnacious","Puritanical","Quirky","Reactionary","Reactive","Regimental","Regretful","Repentant","Repressed","Resentful","Ridiculous","Rigid","Ritualistic","Rowdy","Ruined","Sadistic","Sanctimonious","Scheming","Scornful","Secretive","Sedentary","Selfish","Self-indulgent","Shallow","Shortsighted","Shy","Silly","Single-minded","Sloppy","Slow","Sly","Small-thinking","Softheaded","Sordid","Steely","Stiff","Strong-willed","Stupid","Submissive","Superficial","Superstitious","Suspicious","Tactless","Tasteless","Tense","Thievish","Thoughtless","Timid","Transparent","Treacherous","Trendy","Troublesome","Unappreciative","Uncaring","Uncharitable","Unconvincing","Uncooperative","Uncreative","Uncritical","Unctuous","Undisciplined","Unfriendly","Ungrateful","Unhealthy","Unimaginative","Unimpressive","Unlovable","Unpolished","Unprincipled","Unrealistic","Unreflective","Unreliable","Unrestrained","Unself-critical","Unstable","Vacuous","Vague","Venal","Venomous","Vindictive","Vulnerable","Weak","Weak-willed","Well-meaning","Willful","Wishful","Zany" };
        //638 Total Traits

       
        for(int i=0;i<=4;i++)
        {

            int r = Random.Range(1, 4);
            
            switch (r)
            {
                case 1:
                    {
                        
                        npcTraists.Add(positiveTraits[Random.Range(0, positiveTraits.Count)]);
                        break;
                    }
                case 2:
                    {
                        npcTraists.Add(neturalTraits[Random.Range(0, neturalTraits.Count)]);
                        break;
                    }
                case 3:
                    {
                        npcTraists.Add(negativeTraits[Random.Range(0, negativeTraits.Count)]);
                        break;
                    }
                    
                    
            }
        }

        
    }


}
