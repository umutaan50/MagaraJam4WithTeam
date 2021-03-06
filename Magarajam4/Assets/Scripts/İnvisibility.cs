using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Magara Jam 4

public class İnvisibility : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public float width,height;
    GameObject colider;
    public bool invisible;
    bool onetime = true;
    Animator animator;
    int way = 0;

    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        if (invisible && onetime)
        {
            invisibility();
            onetime = false;
        }
        else if(!invisible)
        {
            visibility();
            onetime = true;
        }
        if (animator != null)
        {
            PlayerMovement pl = gameObject.GetComponent<PlayerMovement>();
            animator.SetBool("Jump", pl.animator.GetBool("Jump"));
            animator.SetBool("İsRunning", pl.animator.GetBool("İsRunning"));
        }
    }

    void invisibility()
    {
        //görsel kısım
        colider = new GameObject("collider");
        colider.transform.SetParent(gameObject.transform);
        colider.transform.localScale += new Vector3((width / 2),(height / 2),0);
        colider.transform.localRotation = Quaternion.Euler(new Vector3(0,way,0));
        SpriteRenderer outrenderer = colider.AddComponent<SpriteRenderer>();
        outrenderer.sprite = spriterenderer.sprite;
        outrenderer.color = new Color(0, 0, 0, 0.30f);
        spriterenderer.sortingOrder = 1;
        spriterenderer.color = new Color(spriterenderer.color.r , spriterenderer.color.g, spriterenderer.color.b, 0.3f);
        colider.transform.localPosition = new Vector3(0, 0, colider.transform.position.z);
        animator = colider.AddComponent<Animator>();
        animator.runtimeAnimatorController = gameObject.GetComponent<Animator>().runtimeAnimatorController;

    }

    void visibility()
    {
        if (colider == null) return;
        Destroy(colider);
        spriterenderer.color = new Color(spriterenderer.color.r, spriterenderer.color.g, spriterenderer.color.b,1); 
        
    }
    T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}