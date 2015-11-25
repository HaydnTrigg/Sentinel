#pragma once
#include <cmath>
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct Vector3D
	{
		static const size_t ComponentSize = sizeof(Component) / sizeof(char);

		static const Vector3D<Component> Zero, One;
		static const Vector3D<Component> UnitX, UnitY, UnitZ;

		Component X, Y, Z;

		Vector3D(const Component x, const Component y, const Component z);
		inline Vector3D() : Vector3D((Component)0, (Component)0, (Component)0) {}

		inline Component Length() const
		{
			return Length(*this);
		}

		inline static const Component Length(const Vector3D<Component> &vector3D)
		{
			return Length(vector3D.X, vector3D.Y, vector3D.Z);
		}

		inline static const Component Length(const Component x, const Component y, const Component z)
		{
			return (Component)sqrt(LengthSquared(x, y, z));
		}

		inline Component LengthSquared() const
		{
			return LengthSquared(*this);
		}

		inline static const Component LengthSquared(const Vector3D<Component> &vector3D)
		{
			return LengthSquared(vector3D.X, vector3D.Y, vector3D.Z);
		}

		inline static const Component LengthSquared(const Component x, const Component y, const Component z)
		{
			return DotProduct(x, y, z, x, y, z);
		}

		inline Component Distance(const Vector3D<Component> &other) const
		{
			return Distance(*this, other);
		}

		inline static const Component Distance(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return Distance(a.X, a.Y, a.Z, b.X, b.Y, a.Z);
		}

		inline static const Component Distance(const Component x1, const Component y1, const Component z1, const Component x2, const Component y2, const Component z2)
		{
			return (Component)sqrt(DistanceSquared(x1, y1, z1, x2, y2, z2));
		}

		inline Component DistanceSquared(const Vector3D<Component> &other) const
		{
			return DistanceSquared(*this, other);
		}

		inline static const Component DistanceSquared(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return DistanceSquared(a.X, a.Y, a.Z, b.X, b.Y, b.Z);
		}

		inline static const Component DistanceSquared(const Component x1, const Component y1, const Component z1, const Component x2, const Component y2, const Component z2)
		{
			auto x = x1 - x2;
			auto y = y1 - y2;
			auto z = z1 - z2;
			return LengthSquared(x, y, z);
		}

		inline Component DotProduct(const Vector3D<Component> &other) const
		{
			return DotProduct(*this, other);
		}

		inline static const Component DotProduct(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return DotProduct(a.X, a.Y, a.Z, b.X, b.Y, b.Z);
		}

		inline static const Component DotProduct(const Component x1, const Component y1, const Component z1, const Component x2, const Component y2, const Component z2)
		{
			return (x1 * x2) + (y1 * y2) + (z1 * z2);
		}

		inline void Normalize()
		{
			operator*=((Component)1 / GetLength());
		}

		inline static Vector3D<Component> Normalize(const Vector3D<Component> &vector3D)
		{
			return vector3D * ((Component)1 / Length(vector3D));
		}

		inline void Cross(const Vector3D<Component> &other)
		{
			operator=(Cross(*this, other));
		}

		inline static Vector3D<Component> Cross(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return Vector3D<Component>(
				(a.Y * b.Z) - (a.Z * b.Y),
				(a.Z * b.X) - (a.X * b.Z),
				(a.X * b.Y) - (a.Y * b.X));
		}

		inline void Reflect(const Vector3D<Component> &direction)
		{
			operator-=(((Component)2 * GetDotProduct(direction)) * direction);
		}

		inline static Vector3D<Component> Reflect(const Vector3D<Component> &position, const Vector3D<Component> &direction)
		{
			return position - (((Component)2 * DotProduct(position, direction)) * direction);
		}

		inline static Vector3D<Component> Min(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return Vector3D<Component>(
				a.X < b.X ? a.X : b.X,
				a.Y < b.Y ? a.Y : b.Y,
				a.Z < b.Z ? a.Z : b.Z);
		}

		inline static Vector3D<Component> Max(const Vector3D<Component> &a, const Vector3D<Component> &b)
		{
			return Vector3D<Component>(
				a.X > b.X ? a.X : b.X,
				a.Y > b.Y ? a.Y : b.Y,
				a.Z > b.Z ? a.Z : b.Z);
		}

		inline void Clamp(const Vector3D<Component> &min, const Vector3D<Component> &max)
		{
			if (X < min.X)
				X = min.X;
			else if (X > max.X)
				X = max.X;
			if (Y < min.Y)
				Y = min.Y;
			else if (Y > max.Y)
				Y = max.Y;
			if (Z < min.Z)
				Z = min.Z;
			else if (Z > max.Z)
				Z = max.Z;
		}

		inline static Vector3D<Component> Clamp(const Vector3D<Component> &vector3D, const Vector3D<Component> &min, const Vector3D<Component> &max)
		{
			return Vector3D<Component>(
				v.X < min.X ? min.X : v.X > max.X ? max.X : v.X,
				v.Y < min.Y ? min.Y : v.Y > max.Y ? max.Y : v.Y,
				v.Z < min.Z ? min.Z : v.Z > max.Z ? max.Z : v.Z);
		}

		inline void Lerp(const Vector3D<Component> &v, const Component amount = 0.5f)
		{
			operator=(Lerp(*this, v, amount));
		}

		inline static Vector3D<Component> Lerp(const Vector3D<Component> &a, const Vector3D<Component> &b, const Component amount = 0.5f)
		{
			return a + ((b - a) * amount);
		}

		inline bool operator==(const Vector3D<Component> &other) const
		{
			return X == other.X &&
				Y == other.Y &&
				Z == other.Z;
		}

		inline bool operator!=(const Vector3D<Component> &other) const
		{
			return X != other.X ||
				Y != other.Y ||
				Z != other.Z;
		}

		inline friend Vector3D<Component> operator+(const Vector3D<Component> &lhs, const Vector3D<Component> &rhs)
		{
			return Vector3D<Component>(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
		}

		inline friend Vector3D<Component> operator+(const Vector3D<Component> &lhs, const Component rhs)
		{
			return Vector3D<Component>(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs);
		}

		inline friend Vector3D<Component> operator+(const Component lhs, const Vector3D<Component> &rhs)
		{
			return Vector3D<Component>(lhs + rhs.X, lhs + rhs.Y, lhs + rhs.Z);
		}

		inline Vector3D<Component> &operator+=(const Vector3D<Component> &other)
		{
			X += other.X;
			Y += other.Y;
			Z += other.Z;
			return *this;
		}

		inline Vector3D<Component> &operator+=(const Component other)
		{
			X += other;
			Y += other;
			Z += other;
			return *this;
		}

		inline Vector3D<Component> &operator-()
		{
			X = -X;
			Y = -Y;
			Z = -Z;
			return *this;
		}

		inline friend std::istream &operator>>(std::istream &in, Vector3D<Component> &vector3D)
		{
			return in
				.read((char *)&vector3D.X, ComponentSize)
				.read((char *)&vector3D.Y, ComponentSize)
				.read((char *)&vector3D.Z, ComponentSize);
		}

		inline friend std::ostream &operator<<(std::ostream &out, Vector3D<Component> &vector3D)
		{
			return out
				.write((char *)&vector3D.X, ComponentSize)
				.write((char *)&vector3D.Y, ComponentSize)
				.write((char *)&vector3D.Z, ComponentSize);
		}
	};
}