#include "Vector3D.hpp"

namespace Sentinel
{
	const Vector3D Vector3D::Zero(0.0f, 0.0f);
	const Vector3D Vector3D::One(1.0f, 1.0f);

	const Vector3D Vector3D::UnitX(1.0f, 0.0f, 0.0f);
	const Vector3D Vector3D::UnitY(0.0f, 1.0f, 0.0f);
	const Vector3D Vector3D::UnitZ(0.0f, 0.0f, 0.0f);

	Vector3D::Vector3D(const float x, const float y, const float z)
		: X(x), Y(y), Z(z) {}

	float Vector3D::GetLength() const
	{
		return Length(*this);
	}

	const float Vector3D::Length(const Vector3D &vector3D)
	{
		return Length(vector3D.X, vector3D.Y, vector3D.Z);
	}

	const float Vector3D::Length(const float x, const float y, const float z)
	{
		return sqrt(LengthSquared(x, y, z));
	}

	float Vector3D::GetLengthSquared() const
	{
		return LengthSquared(*this);
	}

	const float Vector3D::LengthSquared(const Vector3D &vector3D)
	{
		return LengthSquared(vector3D.X, vector3D.Y, vector3D.Z);
	}

	const float Vector3D::LengthSquared(const float x, const float y, const float z)
	{
		return DotProduct(x, y, z, x, y, z);
	}

	float Vector3D::GetDistance(const Vector3D &other) const
	{
		return Distance(*this, other);
	}

	const float Vector3D::Distance(const Vector3D &a, const Vector3D &b)
	{
		return Distance(a.X, a.Y, a.Z, b.X, b.Y, a.Z);
	}

	const float Vector3D::Distance(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2)
	{
		return sqrtf(DistanceSquared(x1, y1, z1, x2, y2, z2));
	}

	float Vector3D::GetDistanceSquared(const Vector3D &other) const
	{
		return DistanceSquared(*this, other);
	}

	const float Vector3D::DistanceSquared(const Vector3D &a, const Vector3D &b)
	{
		return DistanceSquared(a.X, a.Y, a.Z, b.X, b.Y, b.Z);
	}

	const float Vector3D::DistanceSquared(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2)
	{
		auto x = x1 - x2;
		auto y = y1 - y2;
		auto z = z1 - z2;
		return LengthSquared(x, y, z);
	}

	float Vector3D::GetDotProduct(const Vector3D &other) const
	{
		return DotProduct(*this, other);
	}

	const float Vector3D::DotProduct(const Vector3D &a, const Vector3D &b)
	{
		return DotProduct(a.X, a.Y, a.Z, b.X, b.Y, b.Z);
	}

	const float Vector3D::DotProduct(const float x1, const float y1, const float z1, const float x2, const float y2, const float z2)
	{
		return (x1 * x2) + (y1 * y2) + (z1 * z2);
	}

	void Vector3D::Normalize()
	{
		operator*=(1.0f / GetLength());
	}

	Vector3D Vector3D::Normalize(const Vector3D &vector3D)
	{
		return vector3D * (1.0f / Length(vector3D));
	}

	void Vector3D::Cross(const Vector3D &other)
	{
		operator=(Cross(*this, other));
	}

	Vector3D Vector3D::Cross(const Vector3D &a, const Vector3D &b)
	{
		return Vector3D(
			(a.Y * b.Z) - (a.Z * b.Y),
			(a.Z * b.X) - (a.X * b.Z),
			(a.X * b.Y) - (a.Y * b.X));
	}

	void Vector3D::Reflect(const Vector3D &direction)
	{
		operator-=((2.0f * GetDotProduct(direction)) * direction);
	}

	Vector3D Vector3D::Reflect(const Vector3D &position, const Vector3D &direction)
	{
		return position - ((2.0f * DotProduct(position, direction)) * direction);
	}

	Vector3D Vector3D::Min(const Vector3D &a, const Vector3D &b)
	{
		return Vector3D(
			a.X < b.X ? a.X : b.X,
			a.Y < b.Y ? a.Y : b.Y,
			a.Z < b.Z ? a.Z : b.Z);
	}

	Vector3D Vector3D::Max(const Vector3D &a, const Vector3D &b)
	{
		return Vector3D(
			a.X > b.X ? a.X : b.X,
			a.Y > b.Y ? a.Y : b.Y,
			a.Z > b.Z ? a.Z : b.Z);
	}

	void Vector3D::Clamp(const Vector3D &min, const Vector3D &max)
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

	Vector3D Vector3D::Clamp(const Vector3D &v, const Vector3D &min, const Vector3D &max)
	{
		return Vector3D(
			v.X < min.X ? min.X : v.X > max.X ? max.X : v.X,
			v.Y < min.Y ? min.Y : v.Y > max.Y ? max.Y : v.Y,
			v.Z < min.Z ? min.Z : v.Z > max.Z ? max.Z : v.Z);
	}

	void Vector3D::Lerp(const Vector3D &v, const float amount)
	{
		operator=(Lerp(*this, v, amount));
	}

	Vector3D Vector3D::Lerp(const Vector3D &a, const Vector3D &b, const float amount)
	{
		return a + ((b - a) * amount);
	}

	bool Vector3D::operator==(const Vector3D &other) const
	{
		return X == other.X &&
			Y == other.Y &&
			Z == other.Z;
	}

	bool Vector3D::operator!=(const Vector3D &other) const
	{
		return X != other.X ||
			Y != other.Y ||
			Z != other.Z;
	}

	Vector3D operator+(const Vector3D &lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
	}

	Vector3D operator+(const Vector3D &lhs, const float rhs)
	{
		return Vector3D(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs);
	}

	Vector3D operator+(const float lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs + rhs.X, lhs + rhs.Y, lhs + rhs.Z);
	}

	Vector3D &Vector3D::operator+=(const Vector3D &other)
	{
		X += other.X;
		Y += other.Y;
		Z += other.Z;
		return *this;
	}

	Vector3D &Vector3D::operator+=(const float other)
	{
		X += other;
		Y += other;
		Z += other;
		return *this;
	}

	Vector3D &Vector3D::operator-()
	{
		X = -X;
		Y = -Y;
		Z = -Z;
		return *this;
	}

	Vector3D operator-(const Vector3D &lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
	}

	Vector3D operator-(const Vector3D &lhs, const float rhs)
	{
		return Vector3D(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs);
	}

	Vector3D operator-(const float lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs - rhs.X, lhs - rhs.Y, lhs - rhs.Z);
	}

	Vector3D &Vector3D::operator-=(const Vector3D &other)
	{
		X -= other.X;
		Y -= other.Y;
		Z -= other.Z;
		return *this;
	}

	Vector3D &Vector3D::operator-=(const float other)
	{
		X -= other;
		Y -= other;
		Z -= other;
		return *this;
	}

	Vector3D operator*(const Vector3D &lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
	}

	Vector3D operator*(const Vector3D &lhs, const float rhs)
	{
		return Vector3D(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
	}

	Vector3D operator*(const float lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z);
	}

	Vector3D &Vector3D::operator*=(const Vector3D &other)
	{
		X *= other.X;
		Y *= other.Y;
		Z *= other.Z;
		return *this;
	}

	Vector3D &Vector3D::operator*=(const float other)
	{
		X *= other;
		Y *= other;
		Z *= other;
		return *this;
	}

	Vector3D operator/(const Vector3D &lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
	}

	Vector3D operator/(const Vector3D &lhs, const float rhs)
	{
		return Vector3D(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
	}

	Vector3D operator/(const float lhs, const Vector3D &rhs)
	{
		return Vector3D(lhs / rhs.X, lhs / rhs.Y, lhs / rhs.Z);
	}

	Vector3D &Vector3D::operator/=(const Vector3D &other)
	{
		X /= other.X;
		Y /= other.Y;
		Z /= other.Z;
		return *this;
	}

	Vector3D &Vector3D::operator/=(const float other)
	{
		X /= other;
		Y /= other;
		Z /= other;
		return *this;
	}

	std::istream &operator>>(std::istream &in, Vector3D &vector3D)
	{
		return in
			.read((char *)&vector3D.X, 4)
			.read((char *)&vector3D.Y, 4)
			.read((char *)&vector3D.Z, 4);
	}

	std::ostream &operator<<(std::ostream &out, Vector3D &vector3D)
	{
		return out
			.write((char *)&vector3D.X, 4)
			.write((char *)&vector3D.Y, 4)
			.write((char *)&vector3D.Z, 4);
	}
}