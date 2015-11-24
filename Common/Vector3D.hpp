#pragma once
#include <cmath>
#include <iostream>

namespace Sentinel
{
	struct Vector3D
	{
		static const Vector3D Zero, One;
		static const Vector3D UnitX, UnitY, UnitZ;

		float X, Y, Z;

		Vector3D(const float x = 0.0f, const float y = 0.0f, const float z = 0.0f);

		float GetLength() const;
		static const float Length(const Vector3D &vector3D);
		static const float Length(const float x, const float y, const float z);

		float GetLengthSquared() const;
		static const float LengthSquared(const Vector3D &vector3D);
		static const float LengthSquared(const float x, const float y, const float z);

		float GetDistance(const Vector3D &other) const;
		static const float Distance(const Vector3D &a, const Vector3D &b);
		static const float Distance(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2);

		float GetDistanceSquared(const Vector3D &other) const;
		static const float DistanceSquared(const Vector3D &a, const Vector3D &b);
		static const float DistanceSquared(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2);

		float GetDotProduct(const Vector3D &other) const;
		static const float DotProduct(const Vector3D &a, const Vector3D &b);
		static const float DotProduct(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2);

		void Normalize();
		static Vector3D Normalize(const Vector3D &vector3D);

		void Cross(const Vector3D &other);
		static Vector3D Cross(const Vector3D &a, const Vector3D &b);

		void Reflect(const Vector3D &direction);
		static Vector3D Reflect(const Vector3D &position, const Vector3D &direction);

		static Vector3D Min(const Vector3D &a, const Vector3D &b);
		static Vector3D Max(const Vector3D &a, const Vector3D &b);

		void Clamp(const Vector3D &min, const Vector3D &max);
		static Vector3D Clamp(const Vector3D &vector3D, const Vector3D &min, const Vector3D &max);

		void Lerp(const Vector3D &v, const float amount = 0.5f);
		static Vector3D Lerp(const Vector3D &a, const Vector3D &b, const float amount = 0.5f);

		bool operator==(const Vector3D &other) const;
		bool operator!=(const Vector3D &other) const;

		friend Vector3D operator+(const Vector3D &lhs, const Vector3D &rhs);
		friend Vector3D operator+(const Vector3D &lhs, const float rhs);
		friend Vector3D operator+(const float lhs, const Vector3D &rhs);

		Vector3D &operator+=(const Vector3D &other);
		Vector3D &operator+=(const float other);

		Vector3D &operator-();

		friend Vector3D operator-(const Vector3D &lhs, const Vector3D &rhs);
		friend Vector3D operator-(const Vector3D &lhs, const float rhs);
		friend Vector3D operator-(const float lhs, const Vector3D &rhs);

		Vector3D &operator-=(const Vector3D &other);
		Vector3D &operator-=(const float other);

		friend Vector3D operator*(const Vector3D &lhs, const Vector3D &rhs);
		friend Vector3D operator*(const Vector3D &lhs, const float rhs);
		friend Vector3D operator*(const float lhs, const Vector3D &rhs);

		Vector3D &operator*=(const Vector3D &other);
		Vector3D &operator*=(const float other);

		friend Vector3D operator/(const Vector3D &lhs, const Vector3D &rhs);
		friend Vector3D operator/(const Vector3D &lhs, const float rhs);
		friend Vector3D operator/(const float lhs, const Vector3D &rhs);

		Vector3D &operator/=(const Vector3D &other);
		Vector3D &operator/=(const float other);

		friend std::istream &operator>>(std::istream &in, Vector3D &vector3D);
		friend std::ostream &operator<<(std::ostream &out, Vector3D &vector3D);
	};
}