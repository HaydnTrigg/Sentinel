#pragma once
#include <cmath>
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct Vector2D
	{
		static const size_t ComponentSize = sizeof(Component) / sizeof(char);

		static const Vector2D Zero, One;
		static const Vector2D UnitX, UnitY;

		Component X, Y;

		Vector2D(const Component x, const Component y);
		inline Vector2D() : Vector2D((Component)0, (Component)0) {}

		inline Component Length() const
		{
			return Length(*this);
		}

		inline static const Component Length(const Vector2D<Component> &vector2D)
		{
			return Length(vector2D.X, vector2D.Y);
		}

		inline static const Component Length(const Component x, const Component y)
		{
			return (Component)sqrt(LengthSquared(x, y));
		}

		inline Component LengthSquared() const
		{
			return LengthSquared(*this);
		}

		inline static const Component LengthSquared(const Vector2D<Component> &vector2D)
		{
			return LengthSquared(vector2D.X, vector2D.Y);
		}

		inline static const Component LengthSquared(const Component x, const Component y)
		{
			return DotProduct(x, y, x, y);
		}

		inline Component Distance(const Vector2D<Component> &other) const
		{
			return Distance(*this, other);
		}

		inline static const Component Distance(const Vector2D<Component> &a, const Vector2D<Component> &b)
		{
			return Distance(a.X, a.Y, b.X, b.Y);
		}

		inline static const Component Distance(const Component x1, const Component y1, const Component x2, const Component y2)
		{
			return (Component)sqrt(DistanceSquared(x1, y1, x2, y2));
		}

		inline Component DistanceSquared(const Vector2D<Component> &other) const
		{
			return DistanceSquared(*this, other);
		}

		inline static const Component DistanceSquared(const Vector2D<Component> &a, const Vector2D<Component> &b)
		{
			return DistanceSquared(a.X, a.Y, b.X, b.Y);
		}

		inline static const Component DistanceSquared(const Component x1, const Component y1, const Component x2, const Component y2)
		{
			auto x = x1 - x2;
			auto y = y1 - y2;
			return DotProduct(x, y, x, y);
		}

		inline Component DotProduct(const Vector2D<Component> &other) const
		{
			return DotProduct(*this, other);
		}

		inline static const Component DotProduct(const Vector2D<Component> &a, const Vector2D<Component> &b)
		{
			return DotProduct(a.X, a.Y, b.X, b.Y);
		}

		inline static const Component DotProduct(const Component x1, const Component y1, const Component x2, const Component y2)
		{
			return (x1 * x2) + (y1 * y2);
		}

		inline void Normalize()
		{
			operator*=((Component)1 / Length());
		}

		inline static Vector2D<Component> Normalize(const Vector2D<Component> &vector2D)
		{
			return vector2D * ((Component)1 / Length(vector2D));
		}

		inline void Reflect(const Vector2D<Component> &direction)
		{
			operator-=(((Component)2 * DotProduct(direction)) * direction);
		}

		inline static Vector2D<Component> Reflect(const Vector2D<Component> &position, const Vector2D<Component> &direction)
		{
			return position - (((Component)2 * DotProduct(position, direction)) * direction);
		}

		inline static Vector2D<Component> Min(const Vector2D<Component> &a, const Vector2D<Component> &b)
		{
			return Vector2D<Component>(
				a.X < b.X ? a.X : b.X,
				a.Y < b.Y ? a.Y : b.Y);
		}

		inline static Vector2D<Component> Max(const Vector2D<Component> &a, const Vector2D<Component> &b)
		{
			return Vector2D<Component>(
				a.X > b.X ? a.X : b.X,
				a.Y > b.Y ? a.Y : b.Y);
		}

		inline void Clamp(const Vector2D<Component> &min, const Vector2D<Component> &max)
		{
			if (X < min.X)
				X = min.X;
			else if (X > max.X)
				X = max.X;
			if (Y < min.Y)
				Y = min.Y;
			else if (Y > max.Y)
				Y = max.Y;
		}

		inline static Vector2D<Component> Clamp(const Vector2D<Component> &v, const Vector2D<Component> &min, const Vector2D<Component> &max)
		{
			return Vector2D<Component>(
				v.X < min.X ? min.X : v.X > max.X ? max.X : v.X,
				v.Y < min.Y ? min.Y : v.Y > max.Y ? max.Y : v.Y);
		}

		inline void Lerp(const Vector2D<Component> &other, const Component amount)
		{
			operator=(Lerp(*this, other, amount));
		}

		inline static Vector2D<Component> Lerp(const Vector2D<Component> &a, const Vector2D<Component> &b, const Component amount)
		{
			return a + ((b - a) * amount);
		}

		inline bool operator==(const Vector2D<Component> &other) const
		{
			return X == other.X &&
				Y == other.Y;
		}

		inline bool operator!=(const Vector2D<Component> &other) const
		{
			return X != other.X ||
				Y != other.Y;
		}

		inline Vector2D<Component> &operator-()
		{
			X = -X;
			Y = -Y;
			return *this;
		}

		inline friend Vector2D<Component> operator+(const Vector2D<Component> &lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}

		inline friend Vector2D<Component> operator+(const Vector2D<Component> &lhs, const Component rhs)
		{
			return Vector2D<Component>(lhs.X + rhs, lhs.Y + rhs);
		}

		inline friend Vector2D<Component> operator+(const Component lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs + rhs.X, lhs + rhs.Y);
		}

		inline Vector2D<Component> &operator+=(const Vector2D<Component> &other)
		{
			X += other.X;
			Y += other.Y;
			return *this;
		}

		inline Vector2D<Component> &operator+=(const Component other)
		{
			X += other;
			Y += other;
			return *this;
		}

		inline friend Vector2D<Component> operator-(const Vector2D<Component> &lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}

		inline friend Vector2D<Component> operator-(const Vector2D<Component> &lhs, const Component rhs)
		{
			return Vector2D<Component>(lhs.X - rhs, lhs.Y - rhs);
		}

		inline friend Vector2D<Component> operator-(const Component lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs - rhs.X, lhs - rhs.Y);
		}

		inline Vector2D<Component> &operator-=(const Vector2D<Component> &other)
		{
			X -= other.X;
			Y -= other.Y;
			return *this;
		}

		inline Vector2D<Component> &operator-=(const Component other)
		{
			X -= other;
			Y -= other;
			return *this;
		}

		inline friend Vector2D<Component> operator*(const Vector2D<Component> &lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs.X * rhs.X, lhs.Y * rhs.Y);
		}

		inline friend Vector2D<Component> operator*(const Vector2D<Component> &lhs, const Component rhs)
		{
			return Vector2D<Component>(lhs.X * rhs, lhs.Y * rhs);
		}

		inline friend Vector2D<Component> operator*(const Component lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs * rhs.X, lhs * rhs.Y);
		}

		inline Vector2D<Component> &operator*=(const Vector2D<Component> &other)
		{
			X *= other.X;
			Y *= other.Y;
			return *this;
		}

		inline Vector2D<Component> &operator*=(const Component other)
		{
			X *= other;
			Y *= other;
			return *this;
		}

		inline friend Vector2D<Component> operator/(const Vector2D<Component> &lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs.X / rhs.X, lhs.Y / rhs.Y);
		}

		inline friend Vector2D<Component> operator/(const Vector2D<Component> &lhs, const Component rhs)
		{
			return Vector2D<Component>(lhs.X / rhs, lhs.Y / rhs);
		}

		inline friend Vector2D<Component> operator/(const Component lhs, const Vector2D<Component> &rhs)
		{
			return Vector2D<Component>(lhs / rhs.X, lhs / rhs.Y);
		}

		inline Vector2D<Component> &operator/=(const Vector2D<Component> &other)
		{
			X /= other.X;
			Y /= other.Y;
			return *this;
		}

		inline Vector2D<Component> &operator/=(const Component other)
		{
			X /= other;
			Y /= other;
			return *this;
		}

		inline friend std::istream &operator>>(std::istream &in, Vector2D<Component> &vector2D)
		{
			return in
				.read((char *)&vector2D.X, ComponentSize);
				.read((char *)&vector2D.Y, ComponentSize);
		}

		inline friend std::ostream &operator<<(std::ostream &out, Vector2D<Component> &vector2D)
		{
			return out
				.write((char *)&vector2D.X, ComponentSize)
				.write((char *)&vector2D.Y, ComponentSize);
		}
	};
}