using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringButton : MonoBehaviour {

    private Color pressedColor = Color.gray;
    private Color unpressedColor = Color.white;

    private SpriteRenderer buttonSprite;
    private Collider2D buttonCollider;

    public Collider2D latestNoteTouched;

    void Start()
    {
        buttonCollider = transform.GetComponent<Collider2D>();
        buttonSprite = transform.GetComponent<SpriteRenderer>();
    }

    public void PressButton()
    {
        buttonSprite.color = pressedColor;

        if (latestNoteTouched)
            if (Physics2D.IsTouching(buttonCollider, latestNoteTouched))
            {
                CollectNote(latestNoteTouched.GetComponent<Note>());
            }
    }

    public void DepressButton()
    {
        buttonSprite.color = unpressedColor;
    }

    void OnTriggerEnter2D(Collider2D colliderData)
    {
        latestNoteTouched = colliderData;
    }

    void CollectNote(Note noteToCollect)
    {
        noteToCollect.Collect();
    }
}
