using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PresentationCanvas : MonoBehaviour
{
    private const string FragmentationId = "_Fragmentation";

    private const string DirectionsMapId = "_DirectionsMap";
    private const string MultiplierId = "_DirectionsMultiplier";

    private const string DezintegrationId = "_Dezintegration";
    private const string OvertensionId = "_Overtension";
    private const string DisturbancesId = "_Disturbances";

    private const string DisturbancesIntensity = "_DisturbancesIntensity";

    public Material material1;
    public Material material2;

    public Text descText;

    public Text dezintegrationText;
    public Text overtensionText;
    public Text disturbancesText;

    public Text multiplierText;
    public Text intensityText;

    public Text fragmentationText;

    public Image image;

    public List<Sprite> sprites = new List<Sprite>();

    public GameObject object1;
    public GameObject object2;

    private void UpdateSettingTexts()
    {
        float dez = material1.GetFloat(DezintegrationId);
        float over = material1.GetFloat(OvertensionId);
        float disturb = material1.GetFloat(DisturbancesId);

        dezintegrationText.text = "Dezintegration Mode : " + (dez != 0 ? "On" : "Off");
        overtensionText.text = "Overtension Mode : " + (over != 0 ? "On" : "Off");
        disturbancesText.text = "Disturbances Mode : " + (disturb != 0 ? "On" : "Off");

        intensityText.gameObject.SetActive(disturb != 0);
        intensityText.text = "Intensity : " + material1.GetFloat(DisturbancesIntensity);

        multiplierText.text = "Multiplier : " + material1.GetFloat(MultiplierId);

    }

    private void SetFragmentation(float curValue)
    {
        SetProperty(FragmentationId, curValue);

        fragmentationText.text = "Fragmentation : " + (curValue * 100.0f).ToString("00") + " %";
    }

    private void SetProperty(string id, float value)
    {
        material1.SetFloat(id, value);
        material2.SetFloat(id, value);

        UpdateSettingTexts();
    }

    private void ChangeSprite(int id)
    {
        image.sprite = sprites[id];

        material1.SetTexture(DirectionsMapId, sprites[id].texture);
        material2.SetTexture(DirectionsMapId, sprites[id].texture);
    }

    private void Awake()
    {
        UpdateSettingTexts();
        ChangeSprite(0);
        SetProperty(FragmentationId, 0.0f);

    }

    private void ChangeSettings(string text, bool dez, bool overTension, bool disturb, float multiplier,
        float disturbIntensity = 0)
    {
        if (text != null)
        {
            descText.text = text;
        }


        SetProperty(DezintegrationId, dez ? 1.0f : 0.0f);
        SetProperty(DisturbancesId, disturb ? 1.0f : 0.0f);
        SetProperty(OvertensionId, overTension ? 1.0f : 0.0f);

        SetProperty(MultiplierId, multiplier);

        if (disturbIntensity != 0)
        {
            SetProperty(DisturbancesIntensity, disturbIntensity);
        }

    }

    private IEnumerator Presentation()
    {
        ChangeSettings("Dezintegration of models - randomness", true, false, true, 4.5f);
        yield return new WaitForSeconds(1.0f);

       
        for (int i = 0; i < sprites.Count; i++)
        {
            ChangeSprite(i);
            yield return new WaitForSeconds(0.5f);
            yield return ChangeFragmentation(1.0f, 0.0f, 4.0f);
        }

        ChangeSettings("Dezintegration of models - static", true, false, false, 7.5f);
        for (int i = 0; i < sprites.Count; i++)
        {
            ChangeSprite(i);
            yield return new WaitForSeconds(0.5f);
            yield return ChangeFragmentation(1.0f, 0.0f, 4.0f);
        }

        ChangeSettings("Dezintegration of models - different types", true, true, false, 6.5f, 1.0f);

        ChangeSprite(0);
        SetProperty(DisturbancesId, 0.0f);

        SetProperty(MultiplierId, 2.4f);
        yield return ChangeFragmentation(1.0f, 0.0f, 8.0f);
        SetProperty(DisturbancesId, 1.0f);
        yield return ChangeFragmentation(1.0f, 0.0f, 8.0f);
        SetProperty(DisturbancesId, 0.0f);


        SetProperty(MultiplierId, 0.5f);
        yield return ChangeFragmentation(1.0f, 0.0f, 4.0f);
        SetProperty(DisturbancesId, 1.0f);
        yield return ChangeFragmentation(1.0f, 0.0f, 4.0f);
        SetProperty(DisturbancesId, 0.0f);


        ChangeSettings("Changing fragments position - dynamic", false, false, true, 3.0f, 8.0f);
        object2.SetActive(false);
        Vector3 startingPos = object1.transform.position;

        ChangeSprite(0);
        StartCoroutine(ChangeFragmentation(1.0f, 0.0f, 4.0f));
        yield return ChangePosition(object1, object2.transform.position, 4.0f);


        ChangeSprite(1);
        StartCoroutine(ChangeFragmentation(1.0f, 0.0f, 4.0f));
        yield return ChangePosition(object1, startingPos, 4.0f);


        ChangeSettings("Changing fragments position - static", false, false, false, 5.5f, 1.0f);
        ChangeSprite(0);
        StartCoroutine(ChangeFragmentation(1.0f, 0.0f, 6.0f));
        yield return ChangePosition(object1, object2.transform.position, 6.0f);


        ChangeSprite(1);
        StartCoroutine(ChangeFragmentation(1.0f, 0.0f, 6.0f));
        yield return ChangePosition(object1, startingPos, 6.0f);


        ChangeSprite(0);

        ChangeSettings("Teleport models - dynamic", true, false, true, 5.5f, 1.0f);
        yield return Teleport(object1, object2.transform.position, 6.0f);

        ChangeSettings("Teleport models - static", true, false, false, 5.5f, 1.0f);
        yield return Teleport(object1, startingPos, 6.0f);


        ChangeSettings("Teleport models (overtension ON) - dynamic", true, true, true, 2.0f, 1.0f);
        yield return Teleport(object1, object2.transform.position, 6.0f);

        ChangeSettings("Teleport models (overtension ON) - static", true, true, false, 5.5f, 1.0f);
        yield return Teleport(object1, startingPos, 6.0f);


        yield return new WaitForSeconds(0.5f);


        ChangeSettings("Cloud of fragments", false, false, true, 4.0f, 0.1f);
        object2.SetActive(true);
        SetProperty(FragmentationId, 0.3f);
        for (int i = 0; i < 2;i++)
        {
            ChangeSprite(i);
            yield return new WaitForSeconds(4.0f);
        }

        ChangeSettings("Various animations", false, false, true, 4.0f, 1.4f);
        ChangeSprite(4);
        yield return new WaitForSeconds(5.0f);

        yield return null;

        object1.SetActive(false);
        object2.SetActive(false);
    }


    private IEnumerator ChangePosition(GameObject go1, Vector3 newPosition1, GameObject go2, Vector3 newPosition2,
        float time)
    {
        StartCoroutine(ChangePosition(go1, newPosition1, time));
        yield return ChangePosition(go2, newPosition2, time);
    }

    protected IEnumerator ChangePosition(GameObject thisObject, Vector3 newPosition, float time)
    {
        Vector3 startPos = thisObject.transform.localPosition;
        Vector3 currentPos = startPos;
        float curTime = 0.0f;
        while (curTime <= time)
        {
            curTime += Time.deltaTime;
            currentPos = Vector3.Lerp(startPos, newPosition, curTime / time);
            thisObject.transform.localPosition = currentPos;
            yield return null;
        }

        thisObject.transform.localPosition = newPosition;
        yield return null;
    }


    protected IEnumerator Teleport(GameObject objectToTeleport, Vector3 toPos, float time)
    {
        yield return ChangeFragmentation(1.0f, time / 2.0f);
        objectToTeleport.transform.position = toPos;
        yield return ChangeFragmentation(0.0f, time / 2.0f);
    }

    protected IEnumerator ChangeFragmentation(float value1, float value2, float time)
    {
        yield return ChangeFragmentation(value1, time / 2.0f);
        yield return ChangeFragmentation(value2, time / 2.0f);
    }


    protected IEnumerator ChangeFragmentation(float value, float time)
    {
        float startValue = material1.GetFloat(FragmentationId);
        float curTime = 0.0f;
        while (curTime <= time)
        {
            curTime += Time.deltaTime;
            float curValue = -1;
            if (startValue < value)
            {
                curValue = startValue + (value - startValue) * curTime / time;
            }
            else
            {
                curValue = startValue - (startValue - value) * curTime / time;
            }
            SetFragmentation(curValue);

            yield return null;
        }

        SetFragmentation(value);
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Presentation());
        }
    }

}
