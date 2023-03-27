using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Page")]
public class Page : ScriptableObject
{
    [TextArea(8, 16)]
    public string PageContent;

    public string PageSection;

    public Page PrevPage;
    public Page NextPage;

    public Page HomePage;

    public Page InfoPage;
}
