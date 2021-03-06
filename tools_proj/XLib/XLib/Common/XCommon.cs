﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class XCommon : XSingleton<XCommon>
{
    public XCommon() { _idx = 5; }

    public const float FrameStep = (1 / 30.0f);

    private int _idx = 0;

    private int _new_id = 0;

    public int New_id { get { return ++_new_id; } }

    public long UniqueToken
    {
        get { return DateTime.Now.Ticks + New_id; }
    }

    public static List<Renderer> tmpRender = new List<Renderer>();

    public uint XHash(string str)
    {
        if (str == null) return 0;

        uint hash = 0;
        for (int i = 0; i < str.Length; i++)
        {
            hash = (hash << _idx) + hash + str[i];
        }
        return hash;
    }

    public uint XHashLower(string str)
    {
        if (str == null) return 0;

        uint hash = 0;
        for (int i = 0; i < str.Length; i++)
        {
            char c = char.ToLower(str[i]);
            hash = (hash << _idx) + hash + c;
        }
        return hash;
    }

    public uint XHash(StringBuilder str)
    {
        if (str == null) return 0;

        uint hash = 0;
        for (int i = 0; i < str.Length; i++)
        {
            hash = (hash << _idx) + hash + str[i];
        }
        return hash;
    }


    /// <summary>
    /// 叉积
    /// </summary>
    private float CrossProduct(float x1, float z1, float x2, float z2)
    {
        return x1 * z2 - x2 * z1;
    }

    /// <summary>
    /// 线段是否相交 叉积运算
    /// </summary>
    public bool IsLineSegmentCross(Vector3 p1, Vector3 p2, Vector3 q1, Vector3 q2)
    {
        //fast detect
        if (Mathf.Min(p1.x, p2.x) <= Mathf.Max(q1.x, q2.x) &&
            Mathf.Min(q1.x, q2.x) <= Mathf.Max(p1.x, p2.x) &&
            Mathf.Min(p1.z, p2.z) <= Mathf.Max(q1.z, q2.z) &&
            Mathf.Min(q1.z, q2.z) <= Mathf.Max(p1.z, p2.z))
        {
            //( p1 - q1 ) * ( q2 - q1 )
            float p1xq = CrossProduct(p1.x - q1.x, p1.z - q1.z,
                                       q2.x - q1.x, q2.z - q1.z);
            //( p2 - q1 ) * ( q2 - q1 )
            float p2xq = CrossProduct(p2.x - q1.x, p2.z - q1.z,
                                       q2.x - q1.x, q2.z - q1.z);

            //( q1 - p1 ) * ( p2 - p1 )
            float q1xp = CrossProduct(q1.x - p1.x, q1.z - p1.z,
                                       p2.x - p1.x, p2.z - p1.z);
            //( q2 - p1 ) * ( p2 - p1 )
            float q2xp = CrossProduct(q2.x - p1.x, q2.z - p1.z,
                                       p2.x - p1.x, p2.z - p1.z);

            return ((p1xq * p2xq <= 0) && (q1xp * q2xp <= 0));
        }

        return false;
    }

    public Vector3 Horizontal(Vector3 v)
    {
        v.y = 0;
        return v.normalized;
    }


    public void Horizontal(ref Vector3 v)
    {
        v.y = 0;
        v.Normalize();
    }

    public Vector2 HorizontalRotateVetor2(Vector2 v, float degree)
    {
        return HorizontalRotateVetor2(v, degree, true);
    }

    public Vector2 HorizontalRotateVetor2(Vector2 v, float degree, bool normalized)
    {
        degree = -degree;

        float rad = degree * Mathf.Deg2Rad;
        float sinA = Mathf.Sin(rad);
        float cosA = Mathf.Cos(rad);

        float x = v.x * cosA - v.y * sinA;
        float y = v.x * sinA + v.y * cosA;

        v.x = x;
        v.y = y;
        return normalized ? v.normalized : v;
    }


    public Vector3 HorizontalRotateVetor3(Vector3 v, float degree)
    {
        return HorizontalRotateVetor3(v, degree, true);
    }

    public Vector3 HorizontalRotateVetor3(Vector3 v, float degree, bool normalized)
    {
        degree = -degree;

        float rad = degree * Mathf.Deg2Rad;
        float sinA = Mathf.Sin(rad);
        float cosA = Mathf.Cos(rad);

        float x = v.x * cosA - v.z * sinA;
        float z = v.x * sinA + v.z * cosA;

        v.x = x;
        v.z = z;
        return normalized ? v.normalized : v;
    }


    /// <summary>
    /// 顺时针旋转
    /// </summary>
    public bool Clockwise(Vector3 fiduciary, Vector3 relativity)
    {
        float r = fiduciary.z * relativity.x - fiduciary.x * relativity.z;
        return r > 0;
    }

    /// <summary>
    /// 顺时针旋转 
    /// </summary>
    public bool Clockwise(Vector2 fiduciary, Vector2 relativity)
    {
        float r = fiduciary.y * relativity.x - fiduciary.x * relativity.y;
        return r > 0;
    }

    public Vector3 FloatToAngle(float angle)
    {
        return Quaternion.Euler(0, angle, 0) * Vector3.forward;
    }

    public float AngleToFloat(Vector3 dir)
    {
        float face = Vector3.Angle(Vector3.forward, dir);
        return Clockwise(Vector3.forward, dir) ? face : -face;
    }

    public Quaternion FloatToQuaternion(float angle)
    {
        return Quaternion.Euler(0, angle, 0);
    }

    /*
    * rect point sequence:
    * left-bottom-->left-top-->right-top-->right-bottom
    * 
    * the center of rect is the (0, 0) for axis
    */
    public bool IsInRect(Vector3 point, Rect rect, Vector3 center, Quaternion rotation)
    {
        float y = -(rotation.eulerAngles.y % 360) / 180.0f * Mathf.PI;
        /*
         * Quaternion = (xi + yj + zk + w ) = (x, y, z, w)
         * Q = cos (a/2) + i (x * sin(a/2)) + j (y * sin(a/2)) + k (z * sin(a/2))    (a 为旋转角度)
         * Q.w = cos (angle / 2) 
         * Q.x = axis.x * sin (angle / 2)
         * Q.y = axis.y * sin (angle / 2)
         * Q.z = axis.z * sin (angle / 2)
         */
        Quaternion q = Quaternion.identity;
        q.w = Mathf.Cos(y / 2.0f);
        q.x = 0;
        q.y = Mathf.Sin(y / 2.0f);
        q.z = 0;

        point = q * (point - center);
        //return (point.x > rect[0].x && point.x < rect[3].x && point.z > rect[0].z && point.z < rect[2].z);
        return (point.x > rect.xMin && point.x < rect.xMax && point.z > rect.yMin && point.z < rect.yMax);
    }

    public Transform FindChildRecursively(Transform t, string name)
    {
        if (t.name == name)
            return t;
        for (int i = 0; i < t.childCount; i++)
        {
            Transform ct = FindChildRecursively(t.GetChild(i), name);
            if (ct != null)
                return ct;
        }
        return null;
    }

    public Quaternion VectorToQuaternion(Vector3 v)
    {
        return FloatToQuaternion(AngleWithSign(Vector3.forward, v));
    }

    public float AngleWithSign(Vector3 from, Vector3 to)
    {
        float angle = Vector3.Angle(from, to);
        return Clockwise(from, to) ? angle : -angle;
    }

    public bool IsRectCycleCross(float rectw, float recth, Vector3 c, float r)
    {
        Vector3 u = new Vector3(Mathf.Max(Mathf.Abs(c.x) - rectw, 0.0f), 0, Mathf.Max(Mathf.Abs(c.z) - recth, 0.0f));
        return u.sqrMagnitude < r * r;
    }

    /*
        * distance: the distance to be move.
        * timespan: the time to use
        * nearenough: the value considered as we got the destination
        */
    public float GetSmoothFactor(float distance, float timespan, float nearenough)
    {
        float _hitFactor = 0;
        distance = Mathf.Abs(distance);
        if (distance > Mathf.Epsilon)
        {
            float deltaT = Time.smoothDeltaTime;
            float div = nearenough / distance;
            float frame = timespan / deltaT;

            if (frame > 1)
            {
                float q = Mathf.Pow(div, 1.0f / frame);
                _hitFactor = (1 - q) / deltaT;
            }
            else
            {
                _hitFactor = Mathf.Infinity;
            }
        }
        return _hitFactor;
    }

    public bool IsEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < Mathf.Epsilon;
    }


    public bool IsLess(float a, float b)
    {
        float v = a - b;
        return !IsEqual(v, 0) && (v < 0);
    }


    public bool IsGreater(float a, float b)
    {
        float v = a - b;
        return !IsEqual(v, 0) && (v > 0);
    }

    public bool IsEqualLess(float a, float b)
    {
        return IsEqual(a, b) || IsLess(a, b);
    }

    public bool IsEqualGreater(float a, float b)
    {
        return IsEqual(a, b) || IsGreater(a, b);
    }

}
