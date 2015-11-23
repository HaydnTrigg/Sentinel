#pragma once
#include <cmath>
#include <iostream>

namespace Sentinel
{
	struct Vector2D
	{
		static const Vector2D Zero;
		static const Vector2D One;

		float X, Y;

		Vector2D(const float x = 0.0f, const float y = 0.0f);

		float GetLength() const;
		static const float Length(const Vector2D &vector2D);
		static const float Length(const float x, const float y);

		float GetLengthSquared() const;
		static const float LengthSquared(const Vector2D &vector2D);
		static const float LengthSquared(const float x, const float y);

		float GetDistance(const Vector2D &other) const;
		static const float Distance(const Vector2D &a, const Vector2D &b);
		static const float Distance(const float x1, const float y1, const float x2, const float y2);

		float GetDistanceSquared(const Vector2D &other) const;
		static const float DistanceSquared(const Vector2D &a, const Vector2D &b);
		static const float DistanceSquared(const float x1, const float y1, const float x2, const float y2);

		float GetDotProduct(const Vector2D &other) const;
		static const float DotProduct(const Vector2D &a, const Vector2D &b);
		static const float DotProduct(const float x1, const float y1, const float x2, const float y2);

		void Normalize();
		static Vector2D Normalize(const Vector2D &vector2D);

		void Reflect(const Vector2D &direction);
		static Vector2D Reflect(const Vector2D &position, const Vector2D &direction);

		static Vector2D Min(const Vector2D &a, const Vector2D &b);
		static Vector2D Max(const Vector2D &a, const Vector2D &b);

		void Clamp(const Vector2D &min, const Vector2D &max);
		static Vector2D Clamp(const Vector2D &vector2D, const Vector2D &min, const Vector2D &max);

		void LerpFrom(const Vector2D &a, const Vector2D &b, const float amount = 0.5f);
		static Vector2D Lerp(const Vector2D &a, const Vector2D &b, const float amount = 0.5f);

		bool operator==(const Vector2D &other) const;
		bool operator!=(const Vector2D &other) const;

		friend Vector2D operator+(const Vector2D &lhs, const Vector2D &rhs);
		friend Vector2D operator+(const Vector2D &lhs, const float rhs);
		friend Vector2D operator+(const float lhs, const Vector2D &rhs);

		Vector2D &operator+=(const Vector2D &other);
		Vector2D &operator+=(const float other);

		friend Vector2D operator-(const Vector2D &lhs, const Vector2D &rhs);
		friend Vector2D operator-(const Vector2D &lhs, const float rhs);
		friend Vector2D operator-(const float lhs, const Vector2D &rhs);

		Vector2D &operator-=(const Vector2D &other);
		Vector2D &operator-=(const float other);

		friend Vector2D operator*(const Vector2D &lhs, const Vector2D &rhs);
		friend Vector2D operator*(const Vector2D &lhs, const float rhs);
		friend Vector2D operator*(const float lhs, const Vector2D &rhs);

		Vector2D &operator*=(const Vector2D &other);
		Vector2D &operator*=(const float other);

		friend Vector2D operator/(const Vector2D &lhs, const Vector2D &rhs);
		friend Vector2D operator/(const Vector2D &lhs, const float rhs);
		friend Vector2D operator/(const float lhs, const Vector2D &rhs);

		Vector2D &operator/=(const Vector2D &other);
		Vector2D &operator/=(const float other);

		friend std::istream &operator>>(std::istream &in, Vector2D &vector2D);
		friend std::ostream &operator<<(std::ostream &out, Vector2D &vector2D);
	};
}