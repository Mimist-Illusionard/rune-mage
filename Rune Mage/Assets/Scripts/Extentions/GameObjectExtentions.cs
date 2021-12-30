using UnityEngine;


public static class GameObjectExtentions
{
    public static T GetComponentInObject<T>(this GameObject gameObject) where T : Component
    {
        T result = null;
        if (!gameObject) return null;
        if (gameObject.GetComponent<T>())
        {
            result = gameObject.GetComponent<T>();
            return result;
        }

        if (gameObject.GetComponentInChildren<T>())
        {
            result = gameObject.GetComponentInChildren<T>();
            return result;
        }

        if (gameObject.GetComponentInParent<T>())
        {
            result = gameObject.GetComponentInParent<T>();
            return result;
        }

        return null;
    }

    public static T GetComponentInObject<T>(this Collider collider) where T : Component
    {
        T result = null;
        if (!collider) return null;
        if (collider.GetComponent<T>())
        {
            result = collider.GetComponent<T>();
            return result;
        }

        if (collider.GetComponentInChildren<T>())
        {
            result = collider.GetComponentInChildren<T>();
            return result;
        }

        if (collider.GetComponentInParent<T>())
        {
            result = collider.GetComponentInParent<T>();
            return result;
        }

        return null;
    }

    public static bool TryGetComponentInObject<T>(this Collider collider, out T result) where T : Component
    {
        result = default(T);
        if (!collider) return false;

        if (collider.GetComponent<T>())
        {
            result = collider.GetComponent<T>();
            return true;
        }

        if (collider.GetComponentInChildren<T>())
        {
            result = collider.GetComponentInChildren<T>();
            return true;
        }

        if (collider.GetComponentInParent<T>())
        {
            result = collider.GetComponentInParent<T>();
            return true;
        }

        return false;
    }

    public static bool TryGetComponentInObject<T>(this GameObject gameObject, out T result) where T : Component
    {
        result = default(T);
        if (!gameObject) return false;

        if (gameObject.GetComponent<T>())
        {
            result = gameObject.GetComponent<T>();
            return true;
        }

        if (gameObject.GetComponentInChildren<T>())
        {
            result = gameObject.GetComponentInChildren<T>();
            return true;
        }

        if (gameObject.GetComponentInParent<T>())
        {
            result = gameObject.GetComponentInParent<T>();
            return true;
        }

        return false;
    }
}
